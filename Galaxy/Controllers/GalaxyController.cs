using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Galaxy.Models;

namespace Galaxy.Controllers
{
    public class GalaxyController : Controller
    {
        // GET: Galaxy
        DB_GalaxyEntities db = new DB_GalaxyEntities();
        public ActionResult Index()
        {
            var developer = db.TBL_DEVELOPER.ToList();
            return View(developer);
        }
        [HttpGet]
        public ActionResult AddDeveloper() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDeveloper(TBL_DEVELOPER devekle) 
        {
            db.TBL_DEVELOPER.Add(devekle);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeveloperSil(int  id)
        {
            var developer=db.TBL_DEVELOPER.Find(id);
            db.TBL_DEVELOPER.Remove(developer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeveloperGuncelle(int id)
        {
            var dvlpr = db.TBL_DEVELOPER.Find(id);
            return View("DeveloperGuncelle", dvlpr);
        }
        public ActionResult DevGuncelle(TBL_DEVELOPER t)
        {
            var dev = db.TBL_DEVELOPER.Find(t.DEV_ID);
            dev.NAME = t.NAME;
            dev.SURNAME = t.SURNAME;
            dev.DEV_LVL = t.DEV_LVL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
          
    }
}