using System.Collections.Generic;
using System.Linq;
using ToDoList.DataAccessLayer.Abstract;
using ToDoList.DataAccessLayer.Entity;
using ToDoList.DataAccessLayer.Request;
using ToDoList.DataAccessLayer.ToDoContext;

namespace ToDoList.DataAccessLayer.Concrete
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ToDoDbContext _toDoDbContext;
        public ToDoRepository(ToDoDbContext toDoDbContext)
        {
            _toDoDbContext = toDoDbContext;
        }
        public int AddToDo(ToDo toDo)
        {
            _toDoDbContext.ToDos.Add(toDo);
            SaveChanges();
            return toDo.Id;
        }

        public void DeleteToDo(int id)
        {
            var toDo = _toDoDbContext.ToDos.FirstOrDefault(x => x.Id == id);
            _toDoDbContext.ToDos.Remove(toDo);
            SaveChanges();
        }

        public ToDo GetToDo(int id)
        {
            return _toDoDbContext.ToDos.FirstOrDefault(x => x.Id == id);
        }

        public List<ToDo> GetToDoList()
        {
            return _toDoDbContext.ToDos.ToList();
        }

        public void UpdateToDo(UpdateToDoRequest updateToDoRequest)
        {
            var toDo = _toDoDbContext.ToDos.FirstOrDefault(x => x.Id == updateToDoRequest.Id);
            toDo.Name = updateToDoRequest.Name;
            toDo.Description = updateToDoRequest.Description;
            toDo.TimeToDo = updateToDoRequest.TimeToDo;
            SaveChanges();
        }
        private void SaveChanges()
        {
            _toDoDbContext.SaveChanges();
        }
    }
}
