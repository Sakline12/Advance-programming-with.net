using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Models;
/*using Person.Models;*/

namespace Model.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Information()
        {
            Person a1 = new Person()
            {
              Name="P.K.M.Sakline Bari Heemel",
              Age="22",
              Semester="11th"

            };
            return View(a1);
        }
    }
}