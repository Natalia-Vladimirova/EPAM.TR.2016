using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WcfToDoService.Entities;

namespace WcfToDoService.Repositories
{
    public class WcfRepository
    {
        private readonly ReaderWriterLockSlim readerWriterLock = new ReaderWriterLockSlim();

        private readonly List<ToDoModel> todos = new List<ToDoModel>();

        private readonly IdGenerator idGenerator = new IdGenerator();
        
        public IList<ToDoModel> GetTodos(int userId)
        {
            readerWriterLock.EnterReadLock();

            try
            {
                return todos;
            }
            finally
            {
                readerWriterLock.ExitReadLock();
            }
        }

        public ToDoModel GetTodoByWcfId(int wcfToDoId)
        {
            return todos.FirstOrDefault(t => t.ToDoId == wcfToDoId);
        }

        public bool CreateTodo(ToDoModel todo)
        {
            readerWriterLock.EnterWriteLock();

            try
            {
                if (!IsTodoNew(todo))
                {
                    return false;
                }

                todo.ToDoId = idGenerator.GetNextToDoId();
                todos.Add(todo);
                return true;
            }
            finally
            {
                readerWriterLock.ExitWriteLock();
            }
        }

        public void UpdateTodo(ToDoModel newTodo)
        {
            readerWriterLock.EnterWriteLock();

            try
            {
                var todo = todos.FirstOrDefault(t => t.ToDoId == newTodo.ToDoId);
                if (todo != null)
                {
                    todo.IsCompleted = newTodo.IsCompleted;
                }
            }
            finally
            {
                readerWriterLock.ExitWriteLock();
            }
        }

        public void DeleteTodo(int id)
        {
            readerWriterLock.EnterWriteLock();

            try
            {
                var todo = todos.FirstOrDefault(t => t.ToDoId == id);
                if (todo != null)
                {
                    todos.Remove(todo);
                }
            }
            finally
            {
                readerWriterLock.ExitWriteLock();
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

            public int GetCurrentToDoId()
            {
                return currentId;
            }
        }
    }
}
