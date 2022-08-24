using BLL.BO;
using BLL.Services;
using Presentation_layer.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Presentation_layer.Controllers
{
    [ValidUser]
    public class DoctorAppointmentController : ApiController
    {
        
        [Route("api/appointment")]
        [HttpGet]

        public HttpResponseMessage Get()
        {


/*            var token = Request.Headers.Authorization;
            if (token == null)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized,"Not token Supplied!");
            }*/
            var data = Doctor_Appointment.Get();
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent, "Empty");
        }



        [Route("api/appointment/prescription/{id}")]
        [HttpPut]
        public HttpResponseMessage Update(Doctor_Appointment_Model ap)
        {
            var data = Doctor_Appointment.Update(ap);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotAcceptable, "No Appointment Found");
        }
    }
}
