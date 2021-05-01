using Moq;
using NUnit.Framework;
using System;
using ToDoList.BusinessLayer.Concrete;
using ToDoList.BusinessLayer.Dto.Inputs;
using ToDoList.BusinessLayer.Exceptions;
using ToDoList.DataAccessLayer.Abstract;
using ToDoList.DataAccessLayer.Entity;
using ToDoList.DataAccessLayer.Request;

namespace ToDoList.BusinessTest.ToDoServiceTest
{
    public class UpdateToDoTest
    {
        ToDoService toDoService;
        Mock<IToDoRepository> mockToDoRepository;
        [SetUp]
        public void Setup()
        {
            mockToDoRepository = new Mock<IToDoRepository>();
            toDoService = new ToDoService(mockToDoRepository.Object);
        }
        [Test]
        public void When_Id_IsEmpty()
        {
            UpdateToDoInput updateToDoInput = new UpdateToDoInput();
            Assert.Throws<ValidationException>(() => toDoService.UpdateToDo(updateToDoInput));
        }
        [Test]
        public void When_ToDo_NotFound()
        {
            UpdateToDoInput updateToDoInput = new UpdateToDoInput
            {
                Id = 1
            };
            Assert.Throws<ToDoNotFoundException>(() => toDoService.UpdateToDo(updateToDoInput));
        }
        [Test]
        public void When_UpdateToDo_IsSuccessful()
        {
            ToDo toDo = new ToDo("Kitap", "Kitapkontrolü", new DateTime(2021, 05, 01));
            mockToDoRepository.Setup(x => x.GetToDo(toDo.Id)).Returns(toDo);
            UpdateToDoInput updateToDoInput = new UpdateToDoInput
            {
                Id = toDo.Id,
                Name = "Kitaplık",
                Description = "Kitap kontrolü"
            };

            Assert.DoesNotThrow(() => toDoService.UpdateToDo(updateToDoInput));

            mockToDoRepository.Verify(x => x.UpdateToDo(It.IsAny<UpdateToDoRequest>()), Times.Once());
        }
    }
}
