using BluTimesheet.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BluTimesheet.Models;
using BluTimesheet.Models.DbModels;

namespace BluTimesheet.Services.implementations
{
    public class ReportService : IReportService
    {
        private ActivityService activityService;

        public ReportService(ActivityService activityService)
        {
            this.activityService = activityService;
        }

        public IDictionary<string, int> SumOfHoursSpentOnExactActivityTypePerUser(int activityTypeId)
        {
            throw new NotImplementedException();
        }

        public int SumOfHoursSpentOnProject(int id)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, int> SumOfHoursSpentOnProjectPerUser(int id)
        {
            throw new NotImplementedException();
        }

        public IDictionary<ActivityType, int> SumOfHoursUserSpentOnExactActivityType(int userId)
        {
            throw new NotImplementedException();
        }
    }
}