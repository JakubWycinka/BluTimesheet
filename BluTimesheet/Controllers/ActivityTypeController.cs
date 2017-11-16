using BluTimesheet.Services.interfaces;
using System.Collections.Generic;
using System.Web.Http;
using BluTimesheet.Models.DbModels;

namespace BluTimesheet.Controllers
{
    public class ActivityTypeController : ApiController
    {
        private IActivityTypeService activityTypeService;

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
