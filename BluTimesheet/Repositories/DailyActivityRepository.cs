using BluTimesheet.Context;
using BluTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BluTimesheet.Repositories
{
    public class DailyActivityRepository : IDisposable
    {
        private TimesheetDbContext context;

        public DailyActivityRepository(TimesheetDbContext context)
        {
            this.context = context;
        }

        public void Add(DailyActivity dailyActivity)
        {
            context.DailyActivity.Add(dailyActivity);
            context.SaveChanges();
        }

        public DailyActivity Get(int id)
        {
            return context.DailyActivity.Find(id);
        }
        
        public IEnumerable<DailyActivity> GetAll()
        {
            return context.DailyActivity.AsEnumerable<DailyActivity>();
        }

        public IEnumerable<DailyActivity> GetUserActivites(int id)
        {
            return context.DailyActivity.ToList().Where(x => x.User.Name == "Jozek");
        }

        public void Update(DailyActivity dailyActivity)
        {
            var activityFromDb = context.DailyActivity.SingleOrDefault(activityInDb => activityInDb.Id == dailyActivity.Id);
            if (activityFromDb != null)
            {
                activityFromDb.Begining = dailyActivity.Begining;
                activityFromDb.End = dailyActivity.Begining;
                activityFromDb.Activity = dailyActivity.Activity;
                activityFromDb.Project = dailyActivity.Project;
                context.SaveChanges();
            }
        }

        public void Remove(int id)
        {
            DailyActivity tempDailyActivity = new DailyActivity
            {
                Id = id
        };

            context.DailyActivity.Remove(tempDailyActivity);
            context.SaveChanges();
        }

        public void Approve(DailyActivity dailyActivity)
        {
            var activityFromDb = Get(dailyActivity.Id);
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