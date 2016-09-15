using System.Collections.Generic;
using System.Linq;
using WcfToDoService.Entities;

namespace WcfToDoService.Repositories
{
    public class WcfRepository : IRepository
    {
        private readonly object lockObj = new object();

        private readonly List<ToDoModel> todos = new List<ToDoModel>();

        private readonly IdGenerator idGenerator = new IdGenerator();
        
        public IList<ToDoModel> GetTodos(int userId)
        {
            lock (lockObj)
            {
                return todos;
            }
        }

        public ToDoModel GetTodoByWcfId(int wcfToDoId)
        {
            lock (lockObj)
            {
                return todos.FirstOrDefault(t => t.ToDoId == wcfToDoId);
            }
        }

        public bool CreateTodo(ToDoModel todo)
        {
            lock (lockObj)
            {
                if (!IsTodoNew(todo))
                {
                    return false;
                }

                todo.ToDoId = idGenerator.GetNextToDoId();
                todos.Add(todo);
                return true;
            }
        }

        public void UpdateTodo(ToDoModel newTodo)
        {
            lock (lockObj)
            {
                var todo = todos.FirstOrDefault(t => t.ToDoId == newTodo.ToDoId);
                if (todo != null)
                {
                    todo.IsCompleted = newTodo.IsCompleted;
                }
            }
        }

        public void DeleteTodo(int id)
        {
            lock (lockObj)
            {
                var todo = todos.FirstOrDefault(t => t.ToDoId == id);
                if (todo != null)
                {
                    todos.Remove(todo);
                }
            }
        }
        
        private bool IsTodoNew(ToDoModel todo)
        {
            var oldTodo = todos.FirstOrDefault(t => t.UserId == todo.UserId && t.Name.Trim() == todo.Name.Trim());
            return oldTodo == null;
        }

        private class IdGenerator
        {
            private int currentId;

            public int GetNextToDoId()
            {
                return ++currentId;
            }
        }
    }
}
