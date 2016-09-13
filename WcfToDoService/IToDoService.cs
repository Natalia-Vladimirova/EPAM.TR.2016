using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfToDoService
{
    [ServiceContract]
    public interface IToDoService
    {
        [OperationContract]
        string GetItems(int userId);

        [OperationContract]
        string CreateItem(ToDoMessage item);

        [OperationContract]
        string UpdateItem(ToDoMessage item);

        [OperationContract]
        string DeleteItem(int userId);
    }
}
