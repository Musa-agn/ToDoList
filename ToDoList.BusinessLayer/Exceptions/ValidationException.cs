using System.Net;

namespace ToDoList.BusinessLayer.Exceptions
{
    public class ValidationException : BaseServiceException
    {
        public ValidationException(string propertyName) : base(propertyName + " is invalid.", (int)HttpStatusCode.BadRequest)
        {
        }
    }
}
