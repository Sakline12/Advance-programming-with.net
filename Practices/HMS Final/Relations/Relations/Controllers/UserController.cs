using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Relations.Controllers
{
    public class UserController : ApiController
    {
        [Route("api/User")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var data = UserService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
