using System;

namespace ToDoList.UI.Models.Response
{
    public class GetToDoInfoResponse : ServiceError
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime TimeToDo { get; set; }
    }
}