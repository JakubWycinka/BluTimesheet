using BluTimesheet.Context;
using BluTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BluTimesheet.Repositories
{
    public class ActivityTypeRepository : IDisposable
    {
        private TimesheetDbContext context;

        public ActivityTypeRepository(TimesheetDbContext context)
        {
            this.context = context;
        }

        public void Add(ActivityType activity)
        {
            context.ActivityType.Add(activity);
            context.SaveChanges();
        }

        public ActivityType Get(int id)
        {
            return context.ActivityType.Find(id);
        }

        public void Remove(int id)
        {
            ActivityType tempActivity = new ActivityType
            {
                Id = id
            };
            context.ActivityType.Remove(tempActivity);
            context.SaveChanges();
        }

        public void Update(ActivityType activity)
        {
            var activityFromDb = Get(activity.Id);
            if (activityFromDb != null)
            {                
                activityFromDb.Name = activity.Name;
                context.SaveChanges();
            }

        }

        public IEnumerable<ActivityType> GetAll()
        {
            return context.ActivityType.AsEnumerable();
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