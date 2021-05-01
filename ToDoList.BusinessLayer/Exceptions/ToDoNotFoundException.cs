using System.Net;

namespace ToDoList.BusinessLayer.Exceptions
{
    public class ToDoNotFoundException : BaseServiceException
    {
        public ToDoNotFoundException() : base("To Do not found", (int)HttpStatusCode.NotFound)
        {
        }
    }
}
