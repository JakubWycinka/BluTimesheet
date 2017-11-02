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
            context.SaveChanges();
        }

        public Activity Get(int id)
        {
            return context.Activity.Find(id);
        }

        public void Remove(int id)
        {
            Activity tempActivity = new Activity
            {
                Id = id
            };
            context.Activity.Remove(tempActivity);
            context.SaveChanges();
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