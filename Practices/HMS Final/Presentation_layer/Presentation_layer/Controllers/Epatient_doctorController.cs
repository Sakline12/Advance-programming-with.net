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
    public class Epatient_doctorController : ApiController
    {
        [Route("api/Epatient")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = Epatient_treat.Get();
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent, "Empty");
        }

        [Route("api/Epatient/treatment/{id}")]
        [HttpPut]
        public HttpResponseMessage Update(EpatientModel epatient)
        {
            var data = Epatient_treat.Update(epatient);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, epatient);
            }
            return Request.CreateResponse(HttpStatusCode.NotAcceptable, "No Doctor Found");
        }
    }
}
