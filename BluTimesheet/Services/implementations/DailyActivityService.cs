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

        public void Add(DailyActivity dailyActivity)
        {
            dailyActivityRepository.Add(dailyActivity);
        }

        public void Approve(DailyActivity dailyActivity)
        {
            dailyActivityRepository.Approve(dailyActivity);
        }

        public IEnumerable<DailyActivity> GetAll()
        {
            return dailyActivityRepository.GetAll();
        }

        public DailyActivity Get(int dailyActivityId)
        {
            return dailyActivityRepository.Get(dailyActivityId);
        }

        public void Remove(int dailyActivityId)
        {
            dailyActivityRepository.Remove(dailyActivityId);
        }

        public void Update(DailyActivity dailyActivity)
        {
            dailyActivityRepository.Update(dailyActivity);
        }
    }
}