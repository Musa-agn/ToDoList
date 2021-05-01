using System;

namespace ToDoList.BusinessLayer.Dto.Inputs
{
    public class UpdateToDoInput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime TimeToDo { get; set; }
    }
}
