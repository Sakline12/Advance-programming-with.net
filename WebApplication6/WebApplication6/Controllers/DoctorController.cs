using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Models.Database;

namespace WebApplication6.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        public ActionResult Index()
        {
            HospitalEntities db = new HospitalEntities();
            var data = db.Doctors.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Doctor());
        }
        [HttpPost]
        public ActionResult Create(Doctor d)
        {
            if (ModelState.IsValid)
            {
                HospitalEntities db = new HospitalEntities();
                db.Doctors.Add(d);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(d);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            HospitalEntities db = new HospitalEntities();
            var doctor = (from d in db.Doctors
                          where d.Id == id
                          select d).FirstOrDefault();
            return View(doctor);
                        
        }
        [HttpPost]
        public ActionResult Edit(Doctor change_d)
        {
            HospitalEntities db = new HospitalEntities();
            var doctor = (from d in db.Doctors
                          where d.Id == change_d.Id
                          select d).FirstOrDefault();
            db.Entry(doctor).CurrentValues.SetValues(change_d);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            HospitalEntities db = new HospitalEntities();
            var doctor = (from d in db.Doctors
                          where d.Id == id
                          select d).FirstOrDefault();
            return View(doctor);
        }
        [HttpPost]
        public ActionResult Delete(Doctor change_d)
        {
            HospitalEntities db = new HospitalEntities();
            var doctor = (from d in db.Doctors
                          where d.Id == change_d.Id
                          select d).FirstOrDefault();

            db.Doctors.Remove(doctor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}