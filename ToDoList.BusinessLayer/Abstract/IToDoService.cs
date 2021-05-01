using System.Collections.Generic;
using ToDoList.BusinessLayer.Dto.Inputs;
using ToDoList.BusinessLayer.Dto.Outputs;

namespace ToDoList.BusinessLayer.Abstract
{
    public interface IToDoService
    {
        int AddToDo(AddToDoInput addToDoInput);
        void UpdateToDo(UpdateToDoInput updateToDoInput);
        void DeleteToDo(DeleteToDoInput deleteToDoInput);
        GetToDoInfoOutput GetToDo(int id);
        List<GetToDoInfoOutput> GetToDoList();
    }
}
