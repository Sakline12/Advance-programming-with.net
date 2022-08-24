using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Presentation_layer.Controllers
{
    public class Doctor_NoticeController : ApiController
    {
        [Route("api/DoctorNotice")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = Doctor_Notice.Get();
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent, "Empty");
        }
    }
}
