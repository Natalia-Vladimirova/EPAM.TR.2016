using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfToDoService.Entities;

namespace WcfToDoService.Repositories
{
    public class WcfRepository
    {
        private readonly List<ToDoModel> todos = new List<ToDoModel>();

        public IEnumerable<ToDoModel> GetTodos(int userId)
        {
            return todos;
        }

        public int CreateTodo(ToDoModel todo)
        {
            todos.Add(todo);
            return 0;
        }

        public void UpdateTodo(ToDoModel todo)
        {
            
        }

        public void DeleteTodo(int id)
        {

        }

    }
}
