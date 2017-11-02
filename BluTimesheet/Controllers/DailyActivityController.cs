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
    public class DailyActivityController : ApiController
    {
        private readonly IDailyActivityService dailyActivityService;

        public DailyActivityController(IDailyActivityService dailyActivityService)
        {
            this.dailyActivityService = dailyActivityService;
        }


        public IHttpActionResult PostDailyActivity(DailyActivity dailyActivity)
        {
            dailyActivityService.Add(dailyActivity);
            return Ok();
        }

        public IEnumerable<DailyActivity> GetDailyActivities()
        {
            return dailyActivityService.GetAll();
        }

        public IHttpActionResult GetDailyActivity(int id)
        {
            var dailyActivity = dailyActivityService.Get(id);
            if (dailyActivity != null)
            {
                return Ok(dailyActivity);
            }
            else
            {
                return NotFound();
            }

        }

        public IHttpActionResult PutDailyActivity(DailyActivity dailyActivity)
        {
            dailyActivityService.Update(dailyActivity);
            return Ok();
        }

        public IHttpActionResult DeleteDailyActivity(int id)
        {
            dailyActivityService.Remove(id);
            return Ok();
        }
    }
}
