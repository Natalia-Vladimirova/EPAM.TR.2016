using System.Collections.Generic;
using WcfToDoService.Entities;

namespace WcfToDoService.Repositories
{
    public interface IRepository
    {
        IList<ToDoModel> GetTodos(int userId);

        ToDoModel GetTodoByWcfId(int wcfToDoId);

        bool CreateTodo(ToDoModel todo);

        void UpdateTodo(ToDoModel newTodo);

        void DeleteTodo(int id);
    }
}

