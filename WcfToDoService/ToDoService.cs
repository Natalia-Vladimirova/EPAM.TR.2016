using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfToDoService
{
    public class ToDoService : IToDoService
    {
        public string CreateItem(ToDoMessage item)
        {
            throw new NotImplementedException();
        }

        public string DeleteItem(int userId)
        {
            throw new NotImplementedException();
        }

        public string GetItems(int userId)
        {
            throw new NotImplementedException();
        }

        public string UpdateItem(ToDoMessage item)
        {
            throw new NotImplementedException();
        }
    }
}
