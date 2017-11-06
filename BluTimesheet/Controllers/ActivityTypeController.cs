using BluTimesheet.Models;
using BluTimesheet.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BluTimesheet.Controllers
{
    public class ActivityTypeController : ApiController
    {
        private readonly IActivityTypeService activityTypeService;

        public ActivityTypeController(IActivityTypeService activityTypeService)
        {
            this.activityTypeService = activityTypeService;
        }


        public IHttpActionResult PostActivityType(ActivityType activityType)
        {
            activityTypeService.Add(activityType);
            return Ok();
        }

        
        public IEnumerable<ActivityType> GetActivityTypes()
        {
            return activityTypeService.GetAll();
        }



        public IHttpActionResult GetActivityType(int id)
        {
            var activity = activityTypeService.Get(id);
            if (activity != null)
            {
                return Ok(activity);
            }
            else
            {
                return NotFound();
            }

        }

        public IHttpActionResult PutActivityType(ActivityType activityType)
        {
            activityTypeService.Update(activityType);
            return Ok();
        }

        public IHttpActionResult DeleteActivityType(int id)
        {
            activityTypeService.Remove(id);
            return Ok();
        }
    }
}
