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
        IList<ToDoMessage> InitTodos(int userId);

        [OperationContract]
        IList<ToDoMessage> GetTodos(int userId);

        [OperationContract]
        void CreateTodo(ToDoMessage todo);

        [OperationContract]
        void UpdateTodo(ToDoMessage todo);

        [OperationContract]
        void DeleteTodo(int id);
    }
}
