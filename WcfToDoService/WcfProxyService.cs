using System.Collections.Generic;
using AutoMapper;
using WcfToDoService.Entities;
using WcfToDoService.Services;

namespace WcfToDoService
{
    public class WcfProxyService : IWcfProxyService
    {
        private readonly ToDoService todoService = new ToDoService();

        private readonly UserService userService = new UserService();
        
        public int GetOrCreateUser(string id)
        {
            return userService.GetOrCreateUser(id);
        }

        public IList<ToDoMessage> GetTodos(int userId)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ToDoModel, ToDoMessage>());
            var todos = Mapper.Map<IList<ToDoModel>, IList<ToDoMessage>>(todoService.GetItems(userId));
            return todos;
        }

        public void CreateTodo(ToDoMessage todo, int userId)
        {
            todo.UserId = userId;
            Mapper.Initialize(cfg => cfg.CreateMap<ToDoMessage, ToDoModel>());
            var todoModel = Mapper.Map<ToDoMessage, ToDoModel>(todo);
            todoService.CreateItem(todoModel);
        }

        public void UpdateTodo(ToDoMessage todo, int userId)
        {
            todo.UserId = userId;
            Mapper.Initialize(cfg => cfg.CreateMap<ToDoMessage, ToDoModel>());
            var todoModel = Mapper.Map<ToDoMessage, ToDoModel>(todo);
            todoService.UpdateItem(todoModel);
        }

        public void DeleteTodo(int id)
        {
            todoService.DeleteItem(id);
        }
    }
}
