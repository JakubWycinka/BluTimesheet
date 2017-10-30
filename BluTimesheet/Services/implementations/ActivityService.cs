using BluTimesheet.Repositories;
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

        public void AddActivity(Activity activity)
        {
            activityRepository.Add(activity);
        }

        public List<Activity> GetActivities()
        {
            return activityRepository.GetActivites();
        }

        public Activity GetActivityById(int activityId)
        {
            return activityRepository.GetById(activityId);
        }

        public void RemoveActivityById(int activityId)
        {
            activityRepository.RemoveById(activityId);
        }

        public void UpdateActivity(Activity activity)
        {
            activityRepository.Update(activity);
        }
    }
}