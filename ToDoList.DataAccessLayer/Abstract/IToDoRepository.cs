using System.Collections.Generic;
using ToDoList.DataAccessLayer.Entity;
using ToDoList.DataAccessLayer.Request;

namespace ToDoList.DataAccessLayer.Abstract
{
    public interface IToDoRepository
    {
        int AddToDo(ToDo todo);
        void UpdateToDo(UpdateToDoRequest updateToDoRequest);
        void DeleteToDo(int id);
        ToDo GetToDo(int id);
        List<ToDo> GetToDoList();
    }
}
