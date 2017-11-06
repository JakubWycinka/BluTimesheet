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
    public class ActivityController : ApiController
    {
        private readonly IActivityService activityService;

        public ActivityController(IActivityService activityService)
        {
            this.activityService = activityService;
        }


        public IHttpActionResult PostActivity(Activity activity)
        {
            activityService.Add(activity);
            return Ok();
        }

        public IEnumerable<Activity> GetActivities()
        {
            return activityService.GetAll();
        }

        public IEnumerable<Activity> GetActivitiesByUser(int id)
        {
            return activityService.GetActivitesByUser(id);
        }

        public IEnumerable<Activity> GetActivitiesByProject(int id)
        {
            return activityService.GetActivitesByProject(id);
        }

        public IEnumerable<Activity> GetActivitiesByActivityType(int id)
        {
            return activityService.GetActivitesByActivityType(id);
        }

        public IHttpActionResult GetActivity(int id)
        {
            var dailyActivity = activityService.Get(id);
            if (dailyActivity != null)
            {
                return Ok(dailyActivity);
            }
            else
            {
                return NotFound();
            }

        }

        public IHttpActionResult PutActivity(Activity activity)
        {
            activityService.Update(activity);
            return Ok();
        }

        public IHttpActionResult DeleteActivity(int id)
        {
            activityService.Remove(id);
            return Ok();
        }
    }
}
