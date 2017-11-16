using BluTimesheet.Models.DbModels;
using BluTimesheet.Services.interfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace BluTimesheet.Controllers
{
    public class ActivityController : ApiController
    {
        private IActivityService activityService;

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
        [Route("api/user/{id}/activities")]
        public IEnumerable<Activity> GetActivitiesByUser(string id)
        {
            var elo = activityService.GetActivitesByUser(id);
            return activityService.GetActivitesByUser(id);
        }
        [Route("api/project/{id}/activities")]
        public IEnumerable<Activity> GetActivitiesByProject(int id)
        {
            return activityService.GetActivitesByProject(id);
        }
        [Route("api/activitytype/{id}/activities")]
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
