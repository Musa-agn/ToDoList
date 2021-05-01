using System;

namespace ToDoList.DataAccessLayer.Entity
{
    public class ToDo
    {
        public ToDo(string name, string description, DateTime timeToDo)
        {
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
