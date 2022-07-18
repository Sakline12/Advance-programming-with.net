﻿using HMS.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HMS.Controllers
{
    [Authorize]
    public class DoctorController : Controller
    {
        // GET: Doctor
        public ActionResult Index()
        {
            HospitalEntities db = new HospitalEntities();
            var notices = (from n in db.Notices
                           where n.Type == "D"
                           select n).ToList();

            return View(notices);
        }
        //----------------------------------------------------
        public ActionResult Profile()     //see own profile
        {

            var Id = Int32.Parse(Session["logged_user"].ToString());
            HospitalEntities db = new HospitalEntities();
            var doctor = (from d in db.Registrations
                          where d.Id == Id && d.Type == "D"
                          select d).FirstOrDefault();
            return View(doctor);
        }

        //----------------------------------------------------
        [HttpGet]
        public ActionResult Edit(int Id)        //get value to edit
        {
            HospitalEntities db = new HospitalEntities();
            var doctor = (from d in db.Registrations
                          where d.Id == Id && d.Type == "D"
                          select d).FirstOrDefault();
            return View(doctor);
        }

        [HttpPost]
        public ActionResult Edit(Registration dc)       //edit post
        {
            HospitalEntities db = new HospitalEntities();
            var doctor = (from d in db.Registrations
                          where d.Id == dc.Id
                          select d).FirstOrDefault();


            db.Entry(doctor).CurrentValues.SetValues(dc);
            db.SaveChanges();
            return RedirectToAction("Profile");
        }

        //----------------------------------------------------
        /*[AllowAnonymous]*/
        [HttpGet]
        public ActionResult PatientList()       //see all patients
        {
            HospitalEntities db = new HospitalEntities();
            var allpatients = (from p in db.Registrations
                               where p.Type == "P"
                               select p).ToList();

            //var patients = db.Registrations.ToList();
            return View(allpatients);
        }

        //----------------------------------------------------
        /*[AllowAnonymous]*/
        [HttpGet]
        public ActionResult PatientView(int Id)     //view one from list
        {
            HospitalEntities db = new HospitalEntities();
            var patient = (from p in db.Registrations
                           where p.Id == Id && p.Type == "P"
                           select p).FirstOrDefault();
            return View(patient);
        }
        /*[AllowAnonymous]*/
        [HttpGet]
        public ActionResult Problem()
        {
            var name = Session["Name"].ToString();
            HospitalEntities db = new HospitalEntities();
            var doctor = (from p in db.Registrations
                          where p.Name == name
                          select p).ToList();
            TempData["msg"] = name;
            return View(doctor);

        }
        /*[AllowAnonymous]*/
        [HttpPost]
        public ActionResult Problem(ProblemList d)
        {
            if (ModelState.IsValid)
            {            
            HospitalEntities db = new HospitalEntities();
            db.ProblemLists.Add(d);
            db.SaveChanges();
            TempData["msg"] = "Sent Successfully";

            return RedirectToAction("Index");
            }
            return View(d);

        }
        public ActionResult DonorList()             //All Donor List
        {
            HospitalEntities db = new HospitalEntities();
            var donors = db.Donors.ToList();
            return View(donors);
        }
        //----------------------------------------------------
        /*[AllowAnonymous]*/
        [HttpGet]
        public ActionResult DonorView(int Id)        //get value to edit
        {
            HospitalEntities db = new HospitalEntities();
            var donor = (from d in db.Donors
                         where d.Id == Id
                         select d).FirstOrDefault();
            return View(donor);
        }
        /*[AllowAnonymous]*/
        [HttpPost]
        public ActionResult DonorView(Donor dc)       //edit post
        {
            HospitalEntities db = new HospitalEntities();
            var donor = (from d in db.Donors
                         where d.Id == dc.Id
                         select d).FirstOrDefault();


            db.Entry(donor).CurrentValues.SetValues(dc);
            db.SaveChanges();
            return RedirectToAction("DonorList");
        }
        /*[AllowAnonymous]*/
        [HttpGet]
        public ActionResult EmergencyAppointmentList()      //POSSIBLE AFTER SESSION
        {

            HospitalEntities db = new HospitalEntities();        
            var emergencyappointments = (from a in db.Epatients
                                select a).ToList();
            return View(emergencyappointments);
        }
        /*[AllowAnonymous]*/
        [HttpGet]
        public ActionResult EmergencyPatientList(int Id)       
        {
            HospitalEntities db = new HospitalEntities();        
            var appointments = (from ap in db.Epatients
                                where ap.Id == Id
                                select ap).FirstOrDefault();
            return View(appointments);
        }
        /*[AllowAnonymous]*/
        //Edelete
        public ActionResult Edelete(int Id)     //view one from list
        {
            HospitalEntities db = new HospitalEntities();
            var epatient = (from e in db.Epatients
                           where e.Id.Equals(Id)
                           select e).FirstOrDefault();
            db.Epatients.Remove(epatient);
            db.SaveChanges();

            return RedirectToAction("EmergencyAppointmentList");
        }

    }
}