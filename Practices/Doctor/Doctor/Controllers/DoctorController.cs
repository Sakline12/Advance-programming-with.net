using Doctor.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Doctor.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Doctor.Models.Database.Doctor());
        }
        [HttpPost]
        public ActionResult Create(Doctor.Models.Database.Doctor d)
        {
            if(ModelState.IsValid)
            {
                var db = new HospitalEntities();
                db.Doctors.Add(d);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(d);
        }

    }
}