namespace WcfToDoService.Entities
{
    public class ToDoModel
    {
        public int ToDoId { get; set; }

        public int UserId { get; set; }

        public bool IsCompleted { get; set; }

        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            ToDoModel model = obj as ToDoModel;

            if (model == null)
            {
                return false;
            }

            return ToDoId == model.ToDoId;
        }

        public override int GetHashCode()
        {
            return ToDoId.GetHashCode();
        }
    }
}
