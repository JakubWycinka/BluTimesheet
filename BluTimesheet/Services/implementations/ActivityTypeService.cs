using BluTimesheet.Repositories;
using BluTimesheet.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BluTimesheet.Models;

namespace BluTimesheet.Services.implementations
{
    public class ActivityTypeService : IActivityTypeService
    {
        private readonly ActivityTypeRepository activityTypeRepository;

        public ActivityTypeService(ActivityTypeRepository activityTypeRepository)
        {
            this.activityTypeRepository = activityTypeRepository;
        }

        public void Add(ActivityType activityType)
        {
            activityTypeRepository.Add(activityType);
        }

        public IEnumerable<ActivityType> GetAll()
        {
            return activityTypeRepository.GetAll();
        }

        public ActivityType Get(int id)
        {
            return activityTypeRepository.Get(id);
        }

        public void Remove(int id)
        {
            activityTypeRepository.Remove(id);
        }

        public void Update(ActivityType activityType)
        {
            activityTypeRepository.Update(activityType);
        }
        
    }
}