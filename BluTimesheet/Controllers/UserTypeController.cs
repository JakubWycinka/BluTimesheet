using BluTimesheet.Models;
using BluTimesheet.Services.implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BluTimesheet.Controllers
{
    public class UserTypeController : ApiController
    {
        private readonly UserTypeService userTypeService;

        public UserTypeController(UserTypeService userTypeService)
        {
            this.userTypeService = userTypeService;
        }

        public IHttpActionResult PostUserType(UserType userType)
        {
            userTypeService.Add(userType);
            return Ok();
        }

        public IEnumerable<UserType> GetUserTypes()
        {
            return userTypeService.GetAll();
        }

        public IHttpActionResult GetUserType(int id)
        {
            var userType = userTypeService.Get(id);
            if (userType != null)
            {
                return Ok(userType);
            }
            else
            {
                return NotFound();
            }

        }

        public IHttpActionResult PutUserType(UserType userType)
        {
            
            userTypeService.Update(userType);
            return Ok();
        }

        public IHttpActionResult DeleteUserType(int id)
        {
            userTypeService.Remove(id);
            return Ok();
        }

        [Route("api/usertype/projects")]
        public IEnumerable<User> GetUsers(int id)
        {
            return userTypeService.GetUsers(id);
        }
    }
}
