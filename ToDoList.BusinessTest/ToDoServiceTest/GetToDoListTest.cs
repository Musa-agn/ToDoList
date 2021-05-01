using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using ToDoList.BusinessLayer.Concrete;
using ToDoList.DataAccessLayer.Abstract;
using ToDoList.DataAccessLayer.Entity;

namespace ToDoList.BusinessTest.ToDoServiceTest
{
    public class GetToDoListTest
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
        public void When_GetToDo_IsSuccessful()
        {
            List<ToDo> toDoList = new List<ToDo>();
            toDoList.Add(new ToDo("Kitap", "Kitapkontrolü", new DateTime(2021, 05, 01)));
            mockToDoRepository.Setup(x => x.GetToDoList()).Returns(toDoList);

            Assert.DoesNotThrow(() => toDoService.GetToDoList());

            mockToDoRepository.Verify(x => x.GetToDoList(), Times.Once());
        }
    }
}
