using BluTimesheet.Context;
using BluTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BluTimesheet.Repositories
{
    public class DailyActivityRepository
    {
        private readonly TimesheetDbContext context;

        public DailyActivityRepository(TimesheetDbContext context)
        {
            this.context = context;
        }

        public void AddDailyActivity(DailyActivity dailyActivity)
        {
            context.DailyActivity.Add(dailyActivity); 
        }

        public DailyActivity GetDailyActivityById(int dailyActivityId)
        {
            return context.DailyActivity.Find(dailyActivityId);
        }
        
        public List<DailyActivity> GetAllDailyActivitiesInDb()
        {
            return context.DailyActivity.ToList();
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

        public void RemoveDailyActivityById(int dailyActivityId)
        {
            DailyActivity tempDailyActivity = new DailyActivity
            {
                Id = dailyActivityId
        };

            context.DailyActivity.Remove(tempDailyActivity);
        }

        public void ApproveDailyActivity(DailyActivity dailyActivity)
        {
            var activityFromDb = context.DailyActivity.SingleOrDefault(activityInDb => activityInDb.Id == dailyActivity.Id);
            if (activityFromDb != null)
            {
                activityFromDb.ApprovedByManager = true;
                context.SaveChanges();
            }
        }


    }
}