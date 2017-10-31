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

        public void Add(Activity activity)
        {
            activityRepository.Add(activity);
        }

        public IEnumerable<Activity> GetAll()
        {
            return activityRepository.GetAll();
        }

        public Activity Get(int activityId)
        {
            return activityRepository.Get(activityId);
        }

        public void Remove(int activityId)
        {
            activityRepository.Remove(activityId);
        }

        public void Update(Activity activity)
        {
            activityRepository.Update(activity);
        }
    }
}