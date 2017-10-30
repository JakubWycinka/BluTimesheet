using BluTimesheet.Repositories;
using BluTimesheet.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BluTimesheet.Models;

namespace BluTimesheet.Services.implementations
{
    public class DailyActivityService : IDailyActivityService
    {

        private readonly DailyActivityRepository dailyActivityRepository;

        public DailyActivityService(DailyActivityRepository dailyActivityRepository)
        {
            this.dailyActivityRepository = dailyActivityRepository;
        }

        public void AddDailyActivity(DailyActivity dailyActivity)
        {
            dailyActivityRepository.AddDailyActivity(dailyActivity);
        }

        public void ApproveDailyActivity(DailyActivity dailyActivity)
        {
            dailyActivityRepository.ApproveDailyActivity(dailyActivity);
        }

        public List<DailyActivity> GetActivities()
        {
            return dailyActivityRepository.GetAllDailyActivitiesInDb();
        }

        public DailyActivity GetDailyActivityById(int dailyActivityId)
        {
            return dailyActivityRepository.GetDailyActivityById(dailyActivityId);
        }

        public void RemoveDailyActivityById(int dailyActivityId)
        {
            dailyActivityRepository.RemoveDailyActivityById(dailyActivityId);
        }

        public void UpdateDailyActivity(DailyActivity dailyActivity)
        {
            dailyActivityRepository.Update(dailyActivity);
        }
    }
}