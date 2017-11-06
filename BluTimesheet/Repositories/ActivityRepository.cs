using BluTimesheet.Context;
using BluTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            return context.Activity.Include("ActivityType").Include("Project").FirstOrDefault(x => x.Id == id);
        }
        
        public IEnumerable<Activity> GetAll()
        {
            return context.Activity.Include("ActivityType").Include("Project").AsEnumerable();
        }

        public IEnumerable<Activity> GetActivitesByUser(int id)
        {
            return GetAll().Where(x => x.User.Id == id);
        }
        public IEnumerable<Activity> GetActivitesByProject(int id)
        {
            return GetAll().Where(x => x.Project.Id == id);
        }
        public IEnumerable<Activity> GetActivitesByActivityType(int id)
        {
            return GetAll().Where(x => x.ActivityType.Id == id);
        }

        public void Update(Activity activity)
        {
            var activityFromDb = context.Activity.SingleOrDefault(activityInDb => activityInDb.Id == activity.Id);
            if (activityFromDb != null)
            {
                activityFromDb.Begining = activity.Begining;
                activityFromDb.End = activity.Begining;
                activityFromDb.ActivityType = activity.ActivityType;
                activityFromDb.Project = activity.Project;
                context.SaveChanges();
            }
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

        public void Approve(Activity activity)
        {
            var activityFromDb = Get(activity.Id);
            if (activityFromDb != null)
            {
                activityFromDb.ApprovedByManager = true;
                context.SaveChanges();
            }
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