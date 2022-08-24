using BLL.BO;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Presentation_layer.Controllers
{
    public class DoctorController : ApiController
    {
        [Route("api/doctor")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = Doctor_Services.Get();
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent, "Empty");
        }
        [Route("api/doctor/create")]
        [HttpPost]
        public HttpResponseMessage Create(Doctor_Model st)
        {
            var data = Doctor_Services.Create(st);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Try Again");
        }

        [Route("api/doctor/update/{id}")]
        [HttpPut]
        public HttpResponseMessage Update(Doctor_Model doctor)
        {
            var data = Doctor_Services.Update(doctor);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, doctor);
            }
            return Request.CreateResponse(HttpStatusCode.NotAcceptable, "No Doctor Found");
        }
        [Route("api/doctor/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = Doctor_Services.Delete(id);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Doctor Deleted");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No Such Doctor Found");
        }

        [Route("api/doctor/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = Doctor_Services.GetOnly(id);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No Such Doctor Found");
        }
    }
}

    

