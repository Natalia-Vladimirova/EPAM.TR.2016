namespace WcfToDoService.Entities
{
    public class ToDoModel
    {
        public int ToDoId { get; set; }

        public int UserId { get; set; }

        public bool IsCompleted { get; set; }

        public string Name { get; set; }
    }
}
