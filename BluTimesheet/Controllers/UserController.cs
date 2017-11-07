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
        public IHttpActionResult PostUser(User user)
        {
            userService.Add(user);
            return Ok();
        }

        public IEnumerable<User> GetUsers()
        {
            return userService.GetAll();
        }

        [Route("api/usertype/{id}/users")]
        public IEnumerable<User> GetUsersByUserType(int id)
        {
            return userService.GetUsersByUserType(id);
        }

        public IHttpActionResult GetUser(int id)
        {
            var user = userService.Get(id);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }

        }

        public IHttpActionResult PutUser(User user)
        {
            userService.Update(user);
            return Ok();
        }

        public IHttpActionResult DeleteUser(int id)
        {
            userService.Remove(id);
            return Ok();
        }

        [Route("api/user/{id}/password/reset")]
        [HttpPut]
        public IHttpActionResult ResetPassword(int id)
        {
            userService.ResetPassword(id);
            return Ok();
        }
        
        [Route("api/user/{id}/password/set")]
        [HttpPut]
        public IHttpActionResult SetPassword(User user)
        {
            userService.SetPassword(user);
            return Ok();
        }

        

    }
}
