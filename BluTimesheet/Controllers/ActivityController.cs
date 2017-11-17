using BluTimesheet.Models.DbModels;
using BluTimesheet.Services.interfaces;
using System.Collections.Generic;
using System.Web.Http;
using Microsoft.AspNet.Identity;

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
            activity.UserId = User.Identity.GetUserId();
            activityService.Add(activity);
            return Ok();
        }
        [Authorize(Roles = Startup.roleAdmin)]
        public IEnumerable<Activity> GetActivities()
        {
            return activityService.GetAll();
        }
        [Route("api/user/{id}/activities")]
        public IEnumerable<Activity> GetActivitiesByUser(string id = "")
        {
            if (User.IsInRole(Startup.roleAdmin))
            {
                return activityService.GetActivitesByUser(id);
            }
            else
            {
                return activityService.GetActivitesByUser(User.Identity.GetUserId());
            }
            
        }
        [Authorize(Roles = Startup.roleAdmin)]
        [Route("api/project/{id}/activities")]
        public IEnumerable<Activity> GetActivitiesByProject(int id)
        {
            return activityService.GetActivitesByProject(id);
        }
        [Authorize(Roles = Startup.roleAdmin)]
        [Route("api/activitytype/{id}/activities")]
        public IEnumerable<Activity> GetActivitiesByActivityType(int id)
        {
            return activityService.GetActivitesByActivityType(id);
        }

        public IHttpActionResult GetActivity(int id)
        {
            var activity = activityService.Get(id);
            if (activity != null && activity.UserId.Equals(User.Identity.GetUserId()) || User.IsInRole(Startup.roleAdmin)) 
            {
                return Ok(activity);
            }
            else if (activity != null && !activity.UserId.Equals(User.Identity.GetUserId()))
            {
                return Unauthorized();
            }
            else
            {
                return NotFound();
            }

        }

        public IHttpActionResult PutActivity(Activity activity)
        {
            var activityFromDb = activityService.Get(activity.Id);

            if (activityFromDb != null && activityFromDb.UserId.Equals(User.Identity.GetUserId()))
            {
                activityService.Update(activity);
                return Ok();
            }
            else if (activityFromDb != null && !activityFromDb.UserId.Equals(User.Identity.GetUserId()))
            {
                return Unauthorized();
            }
            else
            {
                return NotFound();
            }
        }

        public IHttpActionResult DeleteActivity(int id)
        {
            var activity = activityService.Get(id);
            if (activity != null && activity.UserId.Equals(User.Identity.GetUserId()))
            {
                activityService.Remove(id);
                return Ok();
            }
            else if (activity != null && !activity.UserId.Equals(User.Identity.GetUserId()))
            {
                return Unauthorized();
            }
            else
            {
                return NotFound();
            }
            
        }
    }
}
