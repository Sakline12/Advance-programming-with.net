using BLL.BO;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Console.Controllers
{
    public class StudentController : ApiController
    {
        [Route ("api/student")]    
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = Student_Services.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);                             
        }

        [Route("api/student/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = Student_Services.GetOnly(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }


        /*        [Route("api/student/single/{id}")]
                [HttpGet]
                public HttpResponseMessage Get(int id)
                {
                    var data = Student_Services.Get(id);
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }*/

        /*        [Route("api/student/count/{id}")]
                [HttpGet]
                public HttpResponseMessage Count(int id)
                {
                    var data = Student_Services.Count(id);
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }*/




        [Route ("api/student/create")]
        [HttpPost]
        public HttpResponseMessage Create(Student_Model st)
        {
            var data = Student_Services.Create(st);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/student/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = Student_Services.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, "Deleted");
        }

        [Route("api/student/update/{id}")]
        [HttpPut]
        public HttpResponseMessage Update(Student_Model student)
        {
            var data = Student_Services.Update(student);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

    }
}
