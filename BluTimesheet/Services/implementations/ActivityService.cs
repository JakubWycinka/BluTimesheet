﻿using BluTimesheet.Repositories;
using BluTimesheet.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BluTimesheet.Models;

namespace BluTimesheet.Services.implementations
{
    public class ActivityService : IActivityService
    {
        private readonly ActivityRepository activityRepository;

        public ActivityService(ActivityRepository activityRepository)
        {
            this.activityRepository = activityRepository;
        }

        public void Add(Activity activity)
        {
            activityRepository.Add(activity);
        }

        public IEnumerable<Activity> GetAll()
        {
            return activityRepository.GetAll();
        }

        public Activity Get(int id)
        {
            return activityRepository.Get(id);
        }

        public void Remove(int id)
        {
            activityRepository.Remove(id);
        }

        public void Update(Activity activity)
        {
            activityRepository.Update(activity);
        }

        public IEnumerable<DailyActivity> GetDailyActivities(int id)
        {
            return Get(id).DailyActivity;
        }
    }
}