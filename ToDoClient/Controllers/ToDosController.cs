using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using ToDoClient.Models;
using ToDoClient.Services;
using ToDoClient.ToDoServiceReference;

namespace ToDoClient.Controllers
{
    /// <summary>
    /// Processes todo requests.
    /// </summary>
    public class ToDosController : ApiController
    {
        private readonly WcfProxyServiceClient wcfService;

        private readonly int currentUserId;

        public ToDosController()
        {
            wcfService = new WcfProxyServiceClient();
            var id = CookieService.GetUserIdFromCookie();
            currentUserId = wcfService.GetOrCreateUser(id);
            CookieService.SaveUserIdInCookie(currentUserId);
        }

        /// <summary>
        /// Returns all todo-items for the current user.
        /// </summary>
        /// <returns>The list of todo-items.</returns>
        public IList<ToDoItemViewModel> Get()
        {
            var items = wcfService.GetTodos(currentUserId);
            Mapper.Initialize(cfg => cfg.CreateMap<ToDoMessage, ToDoItemViewModel>());
            var todos = Mapper.Map<IList<ToDoMessage>, IList<ToDoItemViewModel>>(items);
            return todos;
        }

        /// <summary>
        /// Updates the existing todo-item.
        /// </summary>
        /// <param name="todo">The todo-item to update.</param>
        public void Put(ToDoItemViewModel todo)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ToDoItemViewModel, ToDoMessage>());
            var item = Mapper.Map<ToDoItemViewModel, ToDoMessage>(todo);
            wcfService.UpdateTodo(item, currentUserId);
        }

        /// <summary>
        /// Deletes the specified todo-item.
        /// </summary>
        /// <param name="id">The todo item identifier.</param>
        public void Delete(int id)
        {
            wcfService.DeleteTodo(id);
        }

        /// <summary>
        /// Creates a new todo-item.
        /// </summary>
        /// <param name="todo">The todo-item to create.</param>
        public void Post(ToDoItemViewModel todo)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ToDoItemViewModel, ToDoMessage>());
            var item = Mapper.Map<ToDoItemViewModel, ToDoMessage>(todo);
            wcfService.CreateTodo(item, currentUserId);
        }
    }
}
