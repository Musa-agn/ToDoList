using System;

namespace ToDoList.DataAccessLayer.Request
{
    public class UpdateToDoRequest
    {
        public UpdateToDoRequest(int id, string name, string description, DateTime timeToDo)
        {
            Id = id;
            Name = name;
            Description = description;
            TimeToDo = timeToDo;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime TimeToDo { get; set; }
    }
}
