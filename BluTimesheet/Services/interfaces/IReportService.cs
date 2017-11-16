using BluTimesheet.Models.DbModels;
using System.Collections.Generic;

namespace BluTimesheet.Services.interfaces
{
    public interface IReportService
    {
        int SumOfHoursSpentOnProject(int projectId);
        IDictionary<string, int> SumOfHoursSpentOnProjectPerUser(int projectId);        
        IDictionary<string, int> SumOfHoursSpentOnExactActivityTypePerUser(int activityTypeId);
        IDictionary<ActivityType, int> SumOfHoursUserSpentOnExactActivityType(int userId);

    }
}
