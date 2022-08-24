using Api.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers
{
    public class StudentController : ApiController
    {
        [Route("api/student/get")]
        [HttpGet]
        public HttpResponseMessage Students()
        {
            First_data_baseEntities db = new First_data_baseEntities();
            var students = db.Students.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, students);

        }
        [Route("api/student/get/{id}")]
        [HttpGet]
        public HttpResponseMessage getSudent(int id)
        {
            First_data_baseEntities db = new First_data_baseEntities();
            var st = db.Students.FirstOrDefault(x => x.Id == id);
            return Request.CreateResponse(HttpStatusCode.OK, st);
        }
        [Route("api/student/create")]
        [HttpPost]
        public HttpResponseMessage createStudent(Student s)
        {
            First_data_baseEntities db = new First_data_baseEntities();
            var st = db.Students.Add(s);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, st);
        }
    }
}
