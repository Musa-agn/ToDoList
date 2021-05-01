using System;
using System.Collections.Generic;
using ToDoList.BusinessLayer.Abstract;
using ToDoList.BusinessLayer.Dto.Inputs;
using ToDoList.BusinessLayer.Dto.Outputs;
using ToDoList.BusinessLayer.Exceptions;
using ToDoList.DataAccessLayer.Abstract;
using ToDoList.DataAccessLayer.Entity;

namespace ToDoList.BusinessLayer.Concrete
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _toDoRepository;
        public ToDoService(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public int AddToDo(AddToDoInput addToDoInput)
        {
            AddToDoInputValidate(addToDoInput);
            int getToDoIdAdded = _toDoRepository.AddToDo(
                new ToDo(
                    addToDoInput.Name,
                    addToDoInput.Description,
                    addToDoInput.TimeToDo)
                );
            return getToDoIdAdded;
        }
        private void AddToDoInputValidate(AddToDoInput addToDoInput)
        {
            if (string.IsNullOrEmpty(addToDoInput.Name))
                throw new ValidationException(nameof(addToDoInput.Name));
            if (string.IsNullOrWhiteSpace(addToDoInput.Description))
                throw new ValidationException(nameof(addToDoInput.Description));
            if (addToDoInput.TimeToDo == DateTime.MinValue)
                throw new ValidationException(nameof(addToDoInput.TimeToDo));
        }
        public void DeleteToDo(DeleteToDoInput deleteToDoInput)
        {
            var toDo = _toDoRepository.GetToDo(deleteToDoInput.Id);
            if (toDo == null)
                throw new ToDoNotFoundException();

            _toDoRepository.DeleteToDo(deleteToDoInput.Id);
        }

        public GetToDoInfoOutput GetToDo(int id)
        {
            var todo = _toDoRepository.GetToDo(id);
            if (todo == null)
                throw new ToDoNotFoundException();

            return ParseToDoInfoOutput(todo);
        }
        private GetToDoInfoOutput ParseToDoInfoOutput(ToDo toDo)
        {
            return new GetToDoInfoOutput
            {
                Id = toDo.Id,
                Name = toDo.Name,
                Description = toDo.Description,
                TimeToDo = toDo.TimeToDo
            };
        }
        public List<GetToDoInfoOutput> GetToDoList()
        {
            var toDoList = _toDoRepository.GetToDoList();

            return ParseToDoListInfoOutput(toDoList);
        }
        private List<GetToDoInfoOutput> ParseToDoListInfoOutput(List<ToDo> toDo)
        {
            var toDoListInfo = new List<GetToDoInfoOutput>();
            foreach (var item in toDo)
            {
                toDoListInfo.Add(new GetToDoInfoOutput
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    TimeToDo = item.TimeToDo
                });
            }
            return toDoListInfo;
        }
        public void UpdateToDo(UpdateToDoInput updateToDoInput)
        {
            var toDo = _toDoRepository.GetToDo(updateToDoInput.Id);
            if (toDo == null)
                throw new ToDoNotFoundException();

            UpdateToDoInputValidate(updateToDoInput, toDo);

            _toDoRepository.UpdateToDo(
                new DataAccessLayer.Request.UpdateToDoRequest(
                    updateToDoInput.Id,
                    updateToDoInput.Name,
                    updateToDoInput.Description,
                    updateToDoInput.TimeToDo)
                );
        }
        private void UpdateToDoInputValidate(UpdateToDoInput updateToDoInput, ToDo todo)
        {
            if (string.IsNullOrEmpty(updateToDoInput.Name))
                updateToDoInput.Name = todo.Name;
            if (string.IsNullOrWhiteSpace(updateToDoInput.Description))
                updateToDoInput.Description = todo.Description;
            if (updateToDoInput.TimeToDo == DateTime.MinValue)
                updateToDoInput.TimeToDo = todo.TimeToDo;
        }
    }
}
