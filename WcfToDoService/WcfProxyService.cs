using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.ServiceModel;
using AutoMapper;
using WcfToDoService.Entities;
using WcfToDoService.Services;
using WcfToDoService.Repositories;

namespace WcfToDoService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class WcfProxyService : IWcfProxyService
    {
        private readonly ToDoService todoService = new ToDoService();

        private readonly UserService userService = new UserService();

        private readonly Queue<Task> taskQueue = new Queue<Task>();

        private readonly ReaderWriterLockSlim readerWriterLock = new ReaderWriterLockSlim();

        private readonly Dictionary<string, int> idMapping = new Dictionary<string, int>();

        private readonly WcfRepository repository = new WcfRepository();
        
        public WcfProxyService()
        {
            StartThreadForTodoUpdates();
        }

        public int GetOrCreateUser(string id)
        {
            return userService.GetOrCreateUser(id);
        }

        public IList<ToDoMessage> InitTodos(int userId)
        {
            if (repository.GetTodos(userId).FirstOrDefault(t => t.UserId == userId) == null)
            {
                var cloudTodos = todoService.GetItems(userId);
                foreach (var todo in cloudTodos)
                {
                    idMapping[todo.Name + todo.UserId] = todo.ToDoId;
                    repository.CreateTodo(todo);
                }
            }

            return GetTodos(userId);
        }

        public IList<ToDoMessage> GetTodos(int userId)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ToDoModel, ToDoMessage>());
            var todos = Mapper.Map<IList<ToDoModel>, IList<ToDoMessage>>(repository.GetTodos(userId));
            return todos;
        }

        public void CreateTodo(ToDoMessage todo)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ToDoMessage, ToDoModel>());
            var todoModel = Mapper.Map<ToDoMessage, ToDoModel>(todo);
            var isNew = repository.CreateTodo(todoModel);

            if (!isNew)
            {
                return;
            }

            readerWriterLock.EnterWriteLock();

            try
            {
                taskQueue.Enqueue(new Task(() =>
                {
                    todoService.CreateItem(todoModel);
                    var cloudTodos = todoService.GetItems(todo.UserId);
                    var newTodo = cloudTodos.FirstOrDefault(t => t.UserId == todo.UserId && t.Name.Trim() == todo.Name.Trim());
                    if (newTodo != null)
                    {
                        idMapping[todo.Name + todo.UserId] = newTodo.ToDoId;
                    }
                }));
            }
            finally
            {
                readerWriterLock.ExitWriteLock();
            }
        }

        public void UpdateTodo(ToDoMessage todo)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ToDoMessage, ToDoModel>());
            var todoModel = Mapper.Map<ToDoMessage, ToDoModel>(todo);
            
            repository.UpdateTodo(todoModel);
            readerWriterLock.EnterWriteLock();
            try
            {
                taskQueue.Enqueue(new Task(() =>
                {
                    Mapper.Initialize(cfg => cfg.CreateMap<ToDoMessage, ToDoModel>());
                    var todoCloudModel = Mapper.Map<ToDoMessage, ToDoModel>(todo);
                    int todoCloudId = idMapping[todo.Name + todo.UserId];
                    todoCloudModel.ToDoId = todoCloudId;
                    todoService.UpdateItem(todoCloudModel);
                }));
            }
            finally
            {
                readerWriterLock.ExitWriteLock();
            }
        }

        public void DeleteTodo(int id)
        {
            var todoModel = repository.GetTodoByWcfId(id);
            string todoName = todoModel.Name;
            int todoUserId = todoModel.UserId;

            repository.DeleteTodo(id);

            readerWriterLock.EnterWriteLock();
            try
            {
                taskQueue.Enqueue(new Task(() =>
                {
                    int todoCloudId = idMapping[todoName + todoUserId];
                    todoService.DeleteItem(todoCloudId);
                    idMapping.Remove(todoName + todoUserId);
                }));
            }
            finally
            {
                readerWriterLock.ExitWriteLock();
            }
        }

        private void StartThreadForTodoUpdates()
        {
            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    Task task = null;
                    readerWriterLock.EnterWriteLock();

                    try
                    {
                        if (taskQueue.Count != 0)
                        {
                            task = taskQueue.Dequeue();
                        }
                    }
                    finally
                    {
                        readerWriterLock.ExitWriteLock();
                    }

                    if (task != null)
                    {
                        task.RunSynchronously();
                    }
                }
            });
            thread.Start();
        }
    }
}
