using BluTimesheet.Models.DbModels;
using BluTimesheet.Services.interfaces;
using System.Collections.Generic;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using BluTimesheet.Authorization;
using System.Web;
using Microsoft.AspNet.Identity.Owin;

namespace BluTimesheet.Controllers
{
    public class ActivityController : ApiController
    {
        private IActivityService activityService;
        private ApplicationUserManager userManager;

        public ActivityController(IActivityService activityService)
        {
            this.activityService = activityService;
            this.userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
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
        [Route("api/user/activities")]
        public IHttpActionResult GetActivitiesByUser(string id = "")
        {
            bool insertedId = id != "";

            if (User.IsInRole(Startup.roleAdmin) && insertedId)
            {
                return Ok(activityService.GetActivitesByUser(id));
            }
            else if (User.IsInRole(Startup.roleManager) && insertedId)
            {
                var user = userManager.FindById(id);

                if(user == null)
                {
                    return NotFound();
                }
                else if (user.SuperiorId == User.Identity.GetUserId())
                {
                    return Ok(activityService.GetActivitesByUser(id));
                } else
                {
                    return Unauthorized();
                }
            }
            else
            {
                return Ok(activityService.GetActivitesByUser(User.Identity.GetUserId()));
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
            bool isAuthor = activity.UserId == User.Identity.GetUserId();

            if (activity != null && isAuthor || User.IsInRole(Startup.roleAdmin)) 
            {
                return Ok(activity);
            }
            else if (activity != null && !isAuthor)
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
            bool isAuthor = activityFromDb.UserId == User.Identity.GetUserId();

            if (activityFromDb != null && isAuthor && activityFromDb.ApprovedByManager == false)
            {
                activityService.Update(activity);
                return Ok();
            }
            else if (activityFromDb != null && !isAuthor)
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
            bool isAuthor = activity.UserId == User.Identity.GetUserId();

            if (activity != null && isAuthor)
            {
                activityService.Remove(id);
                return Ok();
            }
            else if (activity != null && !isAuthor)
            {
                return Unauthorized();
            }
            else
            {
                return NotFound();
            }            
        }

        public IHttpActionResult SubmitActivityToManager(int id)
        {
            var activityFromDb = activityService.Get(id);
            bool isAuthor = activityFromDb.UserId == User.Identity.GetUserId();

            if (activityFromDb != null && isAuthor && activityFromDb.ApprovedByManager == false)
            {
                activityService.SubmitToManager(id);
                return Ok();
            }
            else if (activityFromDb != null && !isAuthor)
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
