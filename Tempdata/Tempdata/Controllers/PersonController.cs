using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tempdata.Models;

namespace Tempdata.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Information()
        {
            Person pr = new Person()
            {
                Name = "P.K.M.Sakline Bari Heemel",
                Age = "22",
                Semester = "10th"
            };
            return View(pr);
        }
        public ActionResult Index()
        {
            TempData["msg"] = "Registration Successfull";
            return RedirectToAction("Information");
        }
    }
}