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
    public class ProblemController : ApiController
    {
        [Route("api/problem")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = Doctor_Problem.Get();
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NoContent, "Empty");
        }
        [Route("api/problem/create")]
        [HttpPost]
        public HttpResponseMessage Create(Doctor_problem_Model st)
        {
            var data = Doctor_Problem.Create(st);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Try Again");
        }
        [Route("api/problem/update/{id}")]
        [HttpPut]
        public HttpResponseMessage Update(Doctor_problem_Model pb)
        {
            var data = Doctor_Problem.Update(pb);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotAcceptable, "No Doctor Found");
        }
        [Route("api/problem/delete/{id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {
            var data = Doctor_Problem.Delete(id);
            if (data == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Problem Deleted");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No Such Problem Found");
        }
        [Route("api/problem/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = Doctor_Problem.GetOnly(id);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No Such Problem Found");
        }
    }
}
