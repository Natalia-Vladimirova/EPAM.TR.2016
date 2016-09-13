using System.Runtime.Serialization;

namespace WcfToDoService
{
    [DataContract]
    public class ToDoMessage
    {
        [DataMember]
        public int ToDoId { get; set; }
        
        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public bool IsCompleted { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
