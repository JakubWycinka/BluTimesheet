using BluTimesheet.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BluTimesheet.Models;

namespace BluTimesheet.Services.implementations
{
    public class ReportService : IReportService
    {
        private ActivityService activityService;

        public ReportService(ActivityService activityService)
        {
            this.activityService = activityService;
        }

        public IDictionary<User, int> SumOfHoursSpentOnExactActivityTypePerUser(int activityTypeId)
        {
            throw new NotImplementedException();
        }

        public int SumOfHoursSpentOnProject(int id)
        {
            throw new NotImplementedException();
        }

        public IDictionary<User, int> SumOfHoursSpentOnProjectPerUser(int id)
        {
            throw new NotImplementedException();
        }

        public IDictionary<ActivityType, int> SumOfHoursUserSpentOnExactActivityType(int userId)
        {
            throw new NotImplementedException();
        }
    }
}