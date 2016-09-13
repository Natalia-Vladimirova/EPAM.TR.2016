using System.Collections.Generic;
using System.ServiceModel;

namespace WcfToDoService
{
    [ServiceContract]
    public interface IWcfProxyService
    {
        [OperationContract]
        int GetOrCreateUser(string id);

        [OperationContract]
        IList<ToDoMessage> GetTodos(int userId);

        [OperationContract]
        void CreateTodo(ToDoMessage todo, int userId);

        [OperationContract]
        void UpdateTodo(ToDoMessage todo, int userId);

        [OperationContract]
        void DeleteTodo(int id);
    }
}
