using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Galaxy.Models;

namespace Dispatch.Controllers
{
    public class DispatchController : Controller
    {
        // GET: Dispatch
        DB_GalaxyEntities db = new DB_GalaxyEntities();
        public ActionResult Dispatch()
        {
            var rol = db.TBL_TASK.ToList();
            return View(rol);
        }
        [HttpGet]
        public ActionResult TaskAta()
        {
            return View();
        }
        //public ActionResult TaskCagir(int id)
        //{
        //    var task = db.TBL_TASK.Find(id);
        //    return View("TaskCagir", task);
        //}
        //[HttpPost]
        //public ActionResult TaskGuncelle(TBL_TASK model)
        //{
        //    var task = db.TBL_TASK.Find(model.TASK_ID);
        //    if (task != null)
        //    {
        //        task.LEVEL_ID = model.LEVEL_ID;
        //        db.SaveChanges();
        //    }
        //    return View("Dispatch", task);
        //}

        public ActionResult TaskGuncelle(int id)
        {
            var task = db.TBL_TASK.Find(id);
            return View("TaskGuncelle", task);
        }
        public ActionResult TaskGuncelleme(TBL_TASK t)
        {
            var dev = db.TBL_TASK.Find(t.TASK_ID);
            dev.USER_ID = t.USER_ID;
            dev.LEVEL_ID = t.LEVEL_ID;
            db.SaveChanges();
            return RedirectToAction("Dispatch");
        }
    } 
}

