using System;

namespace ToDoList.BusinessLayer.Dto.Inputs
{
    public class AddToDoInput
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime TimeToDo { get; set; }
    }
}
