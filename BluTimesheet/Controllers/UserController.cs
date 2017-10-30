using BluTimesheet.Controllers.interfaces;
using BluTimesheet.Models;
using BluTimesheet.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BluTimesheet.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService userService;
        
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [Route("api/user/register")]
        [HttpPost]
        public HttpResponseMessage Register(User user)
        {
            userService.AddUser(user);

            return Request.CreateResponse(HttpStatusCode.OK);

        }

       

    }
}
