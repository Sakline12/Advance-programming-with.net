using Crud_registration_login.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Crud_registration_login.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            HospitalEntities db = new HospitalEntities();
            var data = db.Registers.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Registration()
        {
            return View(new Register());
        }
        [HttpPost]
        public ActionResult Registration(Register reg)
        {
            if (ModelState.IsValid)
            {
                HospitalEntities db = new HospitalEntities();
                db.Registers.Add(reg);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reg);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
           
        }
        [HttpPost]
        public ActionResult Login(Register reg)
        {
                var db = new HospitalEntities();
                var register = (from r in db.Registers
                                where r.User_name.Equals(reg.User_name) 
                                && r.Password.Equals(reg.Password)
                                select r).SingleOrDefault();
                if(register !=null){
                    Session["logged_user"] = register.Id;
                    return RedirectToAction("Index","Home");
                }
                
                return View();

            }
            

        
        public ActionResult Welcome()
        {
            return View();
        }

    }
}