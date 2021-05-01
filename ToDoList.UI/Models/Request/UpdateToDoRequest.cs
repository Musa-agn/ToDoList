using System;

namespace ToDoList.UI.Models.Request
{
    public class UpdateToDoRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime TimeToDo { get; set; }
    }
}