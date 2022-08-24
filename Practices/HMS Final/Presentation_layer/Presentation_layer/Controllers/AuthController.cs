﻿using BLL.BO;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Presentation_layer.Controllers
{
    public class AuthController : ApiController
    {
        [Route("api/login")]
        [HttpPost]
        public HttpResponseMessage Login(LoginModel obj)
        {    
        var data = AuthService.Authenticate(obj.UserName, obj.Password);
        if(data!=null)
        {
          return Request.CreateResponse(HttpStatusCode.OK, data);
        }
         return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        [Route("api/Logout")]
        public HttpResponseMessage Logout(TokenModel obj)
        {
            var data = AuthService.Logout(obj);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

    }
}
