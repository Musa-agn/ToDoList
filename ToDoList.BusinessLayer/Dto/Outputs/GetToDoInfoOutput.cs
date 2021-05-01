using System;

namespace ToDoList.BusinessLayer.Dto.Outputs
{
    public class GetToDoInfoOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime TimeToDo { get; set; }
    }
}
