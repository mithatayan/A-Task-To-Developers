using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Galaxy.Models;

namespace Task.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        DB_GalaxyEntities database = new DB_GalaxyEntities();
        public ActionResult Task()
        {
            var task = database.TBL_TASK.ToList();
            return View(task);
        }
        [HttpGet]
        public ActionResult AddTask()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTask(TBL_TASK taskekle)
        {
            database.TBL_TASK.Add(taskekle);
            database.SaveChanges();
            return RedirectToAction("Task");
        }
        public ActionResult TaskSil(int id)
        {
            var task = database.TBL_TASK.Find(id);
            database.TBL_TASK.Remove(task);
            database.SaveChanges();
            return RedirectToAction("Task");
        }
    }
}