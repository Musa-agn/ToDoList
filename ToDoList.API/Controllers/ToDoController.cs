using Microsoft.AspNetCore.Mvc;
using ToDoList.BusinessLayer.Abstract;
using ToDoList.BusinessLayer.Dto.Inputs;

namespace ToDoList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _toDoService;
        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpPost]
        public IActionResult AddToDo([FromBody] AddToDoInput addToDoInput)
        {
            return Ok(_toDoService.AddToDo(addToDoInput));
        }
        [HttpPut]
        public IActionResult UpdateToDo([FromBody] UpdateToDoInput updateToDoInput)
        {
            _toDoService.UpdateToDo(updateToDoInput);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteToDo([FromBody] DeleteToDoInput deleteToDoInput)
        {
            _toDoService.DeleteToDo(deleteToDoInput);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetToDo([FromQuery] int id)
        {
            var todo = _toDoService.GetToDo(id);
            return Ok(todo);
        }
        [HttpGet("gettodolist")]
        public IActionResult GetToDoList()
        {
            var todoList = _toDoService.GetToDoList();
            return Ok(todoList);
        }
    }
}
