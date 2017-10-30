using BluTimesheet.Context;
using BluTimesheet.Models;
using System.Collections.Generic;
using System.Linq;

namespace BluTimesheet.Repositories
{
    public class ActivityRepository
    {
        private readonly TimesheetDbContext context;

        public ActivityRepository(TimesheetDbContext context)
        {
            this.context = context;
        }

        public void Add(Activity activity)
        {
            context.Activity.Add(activity);
        }

        public Activity GetById(int activityId)
        {
            return context.Activity.Find(activityId);
        }

        public void RemoveById(int activityId)
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

        public List<Activity> GetActivites()
        {
            return context.Activity.ToList();
        }
    }
}