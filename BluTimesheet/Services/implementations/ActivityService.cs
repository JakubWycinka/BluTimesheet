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

        public void Add(Activity dailyActivity)
        {
            activityRepository.Add(dailyActivity);
        }

        public void Approve(Activity dailyActivity)
        {
            activityRepository.Approve(dailyActivity);
            
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

        public void Update(Activity dailyActivity)
        {
            activityRepository.Update(dailyActivity);
        }

        public IEnumerable<Activity> GetActivitesByUser(int id)
        {
            return activityRepository.GetActivitesByUser(id);
        }

        public IEnumerable<Activity> GetActivitesByProject(int id)
        {
            return activityRepository.GetActivitesByProject(id);
        }

        public IEnumerable<Activity> GetActivitesByActivityType(int id)
        {
            return activityRepository.GetActivitesByActivityType(id);
        }
    }
}