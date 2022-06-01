using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ViewBag.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Information()
        {
            ViewBag.Name = "P.K.M.Sakline Bari Heemel";
            ViewBag.Age = "22";
            ViewBag.Semester = "10th";
            return View();
        }
    }
}