using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Backbone_Test.DAL;
using Backbone_Test.ViewModels;

namespace Backbone_Test.Controllers
{
    public class TodoController : Controller
    {

        private IRepository<Todo> repository = null;

        public TodoController()
        {
            repository = new TodoRepository();
        }

        public TodoController(IRepository<Todo> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var todos = repository.FindAll();
            var list = new List<TodoViewModel>();
            foreach (Todo t in todos)
                list.Add(new TodoViewModel(t));

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Post(TodoViewModel newTodo)
        {
            Todo todo = new Todo();
            UpdateModel(todo, new[] { "Text", "Done", "Order" });
            ValidateModel(todo);
            repository.Save();
            return Json(new TodoViewModel(todo));
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            Todo todo = repository.Get(id);
            if (todo != null)
            {
                repository.Delete(todo);
                repository.Save();
            }
            return Json(new { });
        }


        public ActionResult Index()
        {
            var todos = repository.FindAll();

            var list = new List<TodoViewModel>();
            foreach (Todo t in todos)
                list.Add(new TodoViewModel(t));

            return View(list);
        }


    }
}
