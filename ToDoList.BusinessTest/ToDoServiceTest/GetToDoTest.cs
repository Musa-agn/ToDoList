using Moq;
using NUnit.Framework;
using System;
using ToDoList.BusinessLayer.Concrete;
using ToDoList.BusinessLayer.Exceptions;
using ToDoList.DataAccessLayer.Abstract;
using ToDoList.DataAccessLayer.Entity;

namespace ToDoList.BusinessTest.ToDoServiceTest
{
    public class GetToDoTest
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
        public void When_ToDo_NotFound()
        {
            int id = 1;
            Assert.Throws<ToDoNotFoundException>(() => toDoService.GetToDo(id));
        }
        [Test]
        public void When_GetToDo_IsSuccessful()
        {
            ToDo toDo = new ToDo("Kitap", "Kitapkontrolü", new DateTime(2021, 05, 01));
            mockToDoRepository.Setup(x => x.GetToDo(toDo.Id)).Returns(toDo);

            Assert.DoesNotThrow(() => toDoService.GetToDo(toDo.Id));

            mockToDoRepository.Verify(x => x.GetToDo(It.IsAny<int>()), Times.Once());
        }
    }
}
