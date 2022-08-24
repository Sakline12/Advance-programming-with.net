using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EF.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Info()
        {
            return View(new Person());
        }
        [HttpPost]
        public ActionResult Info(Person b)
        {
            if (ModelState.IsValid)
            {
                First_data_baseEntities1 db = new First_data_baseEntities1();
                db.Person.Add(b);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }
    }
}