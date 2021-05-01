using System;
using System.Web.Mvc;
using ToDoList.UI.BaseClient;
using ToDoList.UI.Models.Request;

namespace ToDoList.UI.Controllers
{
    public class ToDoController : Controller
    {
        private readonly RestClientHelper _restClientHelper;
        public ToDoController()
        {
            _restClientHelper = new RestClientHelper();
        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult AddToDo(AddToDoRequest addToDoRequest)
        {
            var toDo = _restClientHelper.AddToDo(addToDoRequest);
            if (toDo.IsError)
            {
                toDo.ErrorMessage = toDo.ErrorMessage;
            }

            return Json(toDo);
        }
        public JsonResult UpdateToDo(UpdateToDoRequest updateToDoRequest)
        {
            var toDo = _restClientHelper.UpdateToDo(updateToDoRequest);

            if (toDo.IsError)
            {
                toDo.ErrorMessage = toDo.ErrorMessage;
            }
            return Json(null);
        }
        public JsonResult DeleteToDo(DeleteToDoRequest deleteToDoRequest)
        {
            var toDo = _restClientHelper.DeleteToDo(deleteToDoRequest);
            if (toDo.IsError)
            {
                toDo.ErrorMessage = toDo.ErrorMessage;
            }
            return Json(toDo);
        }
        public JsonResult GetToDo(int id)
        {
            var toDo = _restClientHelper.GetToDo(id);
            if (toDo.IsError)
            {
                toDo.ErrorMessage = toDo.ErrorMessage;
            }
            return Json(toDo, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetToDoList()
        {
            var toDoList = _restClientHelper.GetToDoList();
            return Json(toDoList, JsonRequestBehavior.AllowGet);
        }

    }
}