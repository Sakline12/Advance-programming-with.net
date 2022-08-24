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
    public class Donor_ApprovalController : ApiController
    {
        [Route("api/donor")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = Donor_Approve.Get();
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent, "Empty");
        }

        [Route("api/donor/approve/{id}")]
        [HttpPut]
        public HttpResponseMessage Update(Doctor_donor_Model student)
        {
            var data = Donor_Approve.Update(student);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotAcceptable, "No Donor Found");
        }
    }
}
