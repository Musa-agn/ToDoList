using System;

namespace ToDoList.UI.Models.Request
{
    public class AddToDoRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime TimeToDo { get; set; }
    }
}