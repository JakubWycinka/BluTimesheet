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


        public IHttpActionResult PostActivity(Activity project)
        {
            activityService.Add(project);
            return Ok();
        }

        
        public IEnumerable<Activity> GetActivities()
        {
            return activityService.GetAll();
        }

        [Route("api/activity/dailyactivities")]
        public IEnumerable<DailyActivity> GetActivities(int id)
        {
            return activityService.GetDailyActivities(id);
        }

        public IHttpActionResult GetActivity(int id)
        {
            var activity = activityService.Get(id);
            if (activity != null)
            {
                return Ok(activity);
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

        public IHttpActionResult DeleteProject(int id)
        {
            activityService.Remove(id);
            return Ok();
        }
    }
}
