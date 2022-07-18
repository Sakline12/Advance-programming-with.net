using HMS.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HMS.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Dashbord()
        {

            var id = Int32.Parse(Session["logged_user"].ToString());
            HospitalEntities db = new HospitalEntities();
            var adminn = (from p in db.Registrations
                          where p.Id.Equals(id) && p.Type.Equals("Admin")
                          select p).SingleOrDefault();
            return View(adminn);
        }

        [HttpGet]
        public ActionResult Edit(int Id)        //get value to edit
        {
            var db = new HospitalEntities();
            var admin = (from p in db.Registrations
                         where p.Id == Id && p.Type == "Admin"
                         select p).FirstOrDefault();
            return View(admin);
        }


        [Authorize]
        [HttpPost]
        public ActionResult Edit(Registration data)        //get value to edit
        {
            HospitalEntities db = new HospitalEntities();
            var admin = (from p in db.Registrations
                         where p.Id.Equals(data.Id) && p.Type.Equals("Admin")
                         select p).FirstOrDefault();
            db.Entry(admin).CurrentValues.SetValues(data);
            db.SaveChanges();
            return RedirectToAction("Dashbord");
        }

        [Authorize]
        public ActionResult PattientList()
        {
            HospitalEntities db = new HospitalEntities();
            var allpatients = (from p in db.Registrations
                               where p.Type.Equals("P")
                               select p).ToList();
            return View(allpatients);
        }
        [Authorize]
        [HttpGet]
        public ActionResult SinglePatient(int Id)     //view one from list
        {
            HospitalEntities db = new HospitalEntities();
            var patient = (from p in db.Registrations
                           where p.Id == Id && p.Type == "P"
                           select p).FirstOrDefault();
            return View(patient);
        }
        //single patient edit show
        [Authorize]
        [HttpGet]
        public ActionResult SinglePatientEdit(int Id)     //view one from list
        {
            HospitalEntities db = new HospitalEntities();
            var patient = (from p in db.Registrations
                           where p.Id == Id && p.Type == "P"
                           select p).FirstOrDefault();
            return View(patient);
        }
        //single patient edit submit
        [Authorize]
        [HttpPost]
        public ActionResult SinglePatientEdit(Registration data)     //view one from list
        {
            HospitalEntities db = new HospitalEntities();
            var patient = (from p in db.Registrations
                           where p.Id.Equals(data.Id) && p.Type.Equals("P")
                           select p).FirstOrDefault();
            db.Entry(patient).CurrentValues.SetValues(data);
            db.SaveChanges();
            TempData["msg"] = "Patient Edit Successfull";
            return View(patient);
        }
        //get all doctor
        [Authorize]
        public ActionResult AllDoctorList()
        {
            HospitalEntities db = new HospitalEntities();
            var alldoctor = (from p in db.Registrations
                             where p.Type.Equals("D")
                             select p).ToList();
            return View(alldoctor);
        }
        [Authorize]
        [HttpGet]
        public ActionResult SingleDoctorEdit(int Id)     //view one from list
        {
            HospitalEntities db = new HospitalEntities();
            var doctor = (from p in db.Registrations
                          where p.Id.Equals(Id) && p.Type.Equals("D")
                          select p).FirstOrDefault();
            return View(doctor);
        }
        [Authorize]
        [HttpPost]
        public ActionResult SingleDoctorEdit(Registration data)     //view one from list
        {
            HospitalEntities db = new HospitalEntities();
            var doctor = (from p in db.Registrations
                          where p.Id.Equals(data.Id) && p.Type.Equals("D")
                          select p).FirstOrDefault();
            db.Entry(doctor).CurrentValues.SetValues(data);
            db.SaveChanges();
            TempData["msg"] = "Doctor Edit Successfull";

            return View(doctor);
        }
        //Add doctor
        [Authorize]
        [HttpGet]
        public ActionResult Addoctor()     //view one from list
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult Addoctor(Registration data)     //view one from list
        {
            if (ModelState.IsValid)
            {
                HospitalEntities db = new HospitalEntities();
                db.Registrations.Add(data);
                db.SaveChanges();

                return RedirectToAction("AllDoctorList");
            }
            return View();
        }
        //Notice View
        [HttpGet]
        public ActionResult Notice()
        {
            HospitalEntities db = new HospitalEntities();
            var notice = (from p in db.Notices select p).ToList();
            return View(notice);

        }


        [HttpGet]
        public ActionResult AddNotice()
        {
            HospitalEntities db = new HospitalEntities();
            var doctor = (from p in db.Notices select p).ToList();
            return View(doctor);

        }
        [HttpPost]
        public ActionResult AddNotice(Notice data)
        {

            HospitalEntities db = new HospitalEntities();
            db.Notices.Add(data);
            db.SaveChanges();
            TempData["msg"] = "Doctor Edit Successfull";

            return RedirectToAction("Notice");

        }
        [Authorize]
        public ActionResult DoctorProblems()
        {
            var db = new HospitalEntities();
            var problems = db.ProblemLists.ToList();
            return View(problems);
        }


    }
}