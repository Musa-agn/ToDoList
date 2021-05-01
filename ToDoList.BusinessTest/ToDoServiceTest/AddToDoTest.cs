using Moq;
using NUnit.Framework;
using System;
using ToDoList.BusinessLayer.Concrete;
using ToDoList.BusinessLayer.Dto.Inputs;
using ToDoList.BusinessLayer.Exceptions;
using ToDoList.DataAccessLayer.Abstract;
using ToDoList.DataAccessLayer.Entity;

namespace ToDoList.BusinessTest.ToDoServiceTest
{
    public class AddToDoTest
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
        public void When_Name_IsNull()
        {
            AddToDoInput addToDoInput = new AddToDoInput();
            Assert.Throws<ValidationException>(() => toDoService.AddToDo(addToDoInput));
        }
        [Test]
        public void When_Description_IsNull()
        {
            AddToDoInput addToDoInput = new AddToDoInput
            {
                Name = "Test"
            };
            Assert.Throws<ValidationException>(() => toDoService.AddToDo(addToDoInput));
        }
        [Test]
        public void When_TimeToDo_IsMinVal()
        {
            AddToDoInput addToDoInput = new AddToDoInput
            {
                Name = "Test",
                Description = "Test yazma öğrenilecek"
            };
            Assert.Throws<ValidationException>(() => toDoService.AddToDo(addToDoInput));
        }
        public void When_AddToDo_IsSuccessful()
        {
            AddToDoInput addToDoInput = new AddToDoInput
            {
                Name = "Test",
                Description = "Test yazma öğrenilecek",
                TimeToDo = new DateTime(2021, 04, 30)
            };
            Assert.Throws<ValidationException>(() => toDoService.AddToDo(addToDoInput));
            Assert.DoesNotThrow(() => toDoService.AddToDo(addToDoInput));
            mockToDoRepository.Verify(x => x.AddToDo(It.IsAny<ToDo>()), Times.Once());
        }
    }
}
