using BluTimesheet.Context;
using BluTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BluTimesheet.Repositories
{
    public class ActivityRepository : GenericRepository<Activity>
    {
        
        public ActivityRepository(TimesheetDbContext context) : base(context)
        {           
        }
        
        public void Approve(Activity activity)
        {
            var activityFromDb = Get(activity.Id);
            if (activityFromDb != null)
            {
                activityFromDb.ApprovedByManager = true;
                context.SaveChanges();
            }
        }
    }
}