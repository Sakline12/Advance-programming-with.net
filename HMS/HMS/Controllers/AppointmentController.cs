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
    public class AppointmentController : Controller
    {
        // GET: Appointment
        // For Patient---
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Make(int Id)        //get value to edit
        {
            var name = Session["Name"].ToString();
            var db = new HospitalEntities();
            var doctor = (from d in db.Registrations
                          where d.Id == Id && d.Type == "D"
                          select d).FirstOrDefault();
            TempData["msg"] = name;
            return View(doctor);
        }
        [HttpPost]
        public ActionResult Make(Appointment a)
        {
            if (ModelState.IsValid)
            {
                HospitalEntities db = new HospitalEntities();
                db.Appointments.Add(a);
                db.SaveChanges();
                return RedirectToAction("DoctorList", "Patient", new { area = "Patient" });
            }
            return View(a);
        }
        //----------------------------------------------------
        [HttpGet]
        public ActionResult AppointmentHistory()      //See Own Appointment History
        {
            var name = Session["Name"].ToString();
            var db = new HospitalEntities();
            var appointments = (from a in db.Appointments
                                where a.Patient_Name == name/*Session[Name]*/
                                select a).ToList();
            return View(appointments);
        }
        //----------------------------------------------------
        [HttpGet]
        public ActionResult Appointment_View(int Id)     //View Appointment/Prescription from History  
        {
            var db = new HospitalEntities();
            var appointments = (from ap in db.Appointments
                                where ap.Id == Id //Session[Id]
                                select ap).FirstOrDefault();
            return View(appointments);
        }

        //----------------------------------------------------

        //----------------------------------------------------
        //For Doctor---
        [HttpGet]
        public ActionResult AppointmentList()      //POSSIBLE AFTER SESSION
        {
            var name = Session["Name"].ToString();  //POSSIBLE AFTER SESSION
            HospitalEntities db = new HospitalEntities();        //POSSIBLE AFTER SESSION
            var appointments = (from a in db.Appointments
                                where a.Doctor_Name == name/*Session[Name]*/
                                select a).ToList();
            return View(appointments);
        }
        //----------------------------------------------------
        [HttpGet]
        public ActionResult AppointmentView(int Id)       //POSSIBLE AFTER SESSION
        {                                           //POSSIBLE AFTER SESSION
            HospitalEntities db = new HospitalEntities();        //POSSIBLE AFTER SESSION
            var appointments = (from ap in db.Appointments
                                where ap.Id == Id/*Session[Name]*/
                                select ap).FirstOrDefault();
            return View(appointments);
        }
        [HttpPost]
        public ActionResult AppointmentView(Appointment ap)       //edit post
        {
            HospitalEntities db = new HospitalEntities();
            var appointment = (from a in db.Appointments
                               where a.Id == ap.Id
                               select a).FirstOrDefault();

            db.Entry(appointment).CurrentValues.SetValues(ap);
            db.SaveChanges();
            return RedirectToAction("AppointmentList", new RouteValueDictionary(new { Controller = "Appointment", Action = "AppointmentList" }));
        }
    }
}