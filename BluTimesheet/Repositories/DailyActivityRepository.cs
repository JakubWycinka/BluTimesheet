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
        }

        public DailyActivity Get(int dailyActivityId)
        {
            return context.DailyActivity.Find(dailyActivityId);
        }
        
        public IEnumerable<DailyActivity> GetAll()
        {
            return context.DailyActivity.AsEnumerable<DailyActivity>();
        }

        public void Update(DailyActivity dailyActivity)
        {
            var activityFromDb = context.DailyActivity.SingleOrDefault(activityInDb => activityInDb.Id == dailyActivity.Id);
            if (activityFromDb != null)
            {
                activityFromDb.BeginingHour = dailyActivity.BeginingHour;
                activityFromDb.BeginingMinute = dailyActivity.BeginingMinute;
                activityFromDb.EndingHour = dailyActivity.EndingHour;
                activityFromDb.EndingMinute = dailyActivity.EndingMinute;
                activityFromDb.Date = dailyActivity.Date;
                activityFromDb.Activity = dailyActivity.Activity;
                activityFromDb.Project = dailyActivity.Project;
                context.SaveChanges();
            }
        }

        public void Remove(int dailyActivityId)
        {
            DailyActivity tempDailyActivity = new DailyActivity
            {
                Id = dailyActivityId
        };

            context.DailyActivity.Remove(tempDailyActivity);
        }

        public void Approve(DailyActivity dailyActivity)
        {
            var activityFromDb = context.DailyActivity.SingleOrDefault(activityInDb => activityInDb.Id == dailyActivity.Id);
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