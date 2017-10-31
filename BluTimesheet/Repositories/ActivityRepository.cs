using BluTimesheet.Context;
using BluTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BluTimesheet.Repositories
{
    public class ActivityRepository : IDisposable
    {
        private TimesheetDbContext context;

        public ActivityRepository(TimesheetDbContext context)
        {
            this.context = context;
        }

        public void Add(Activity activity)
        {
            context.Activity.Add(activity);
        }

        public Activity Get(int activityId)
        {
            return context.Activity.Find(activityId);
        }

        public void Remove(int activityId)
        {
            Activity tempActivity = new Activity
            {
                Id = activityId
            };
            context.Activity.Remove(tempActivity);
        }

        public void Update(Activity activity)
        {
            var activityFromDb = context.Activity.SingleOrDefault(activityInDb => activityInDb.Id == activity.Id);
            if (activityFromDb != null)
            {                
                activityFromDb.Name = activity.Name;
                context.SaveChanges();
            }

        }

        public IEnumerable<Activity> GetAll()
        {
            return context.Activity.AsEnumerable<Activity>();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (context != null)
                {
                    context.Dispose();
                    context = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}