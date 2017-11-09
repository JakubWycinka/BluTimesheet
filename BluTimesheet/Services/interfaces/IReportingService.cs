using BluTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluTimesheet.Services.interfaces
{
    public interface IReportService
    {
        int SumOfHoursSpentOnProject(int projectId);
        IDictionary<User, int> SumOfHoursSpentOnProjectPerUser(int projectId);        
        IDictionary<User, int> SumOfHoursSpentOnExactActivityTypePerUser(int activityTypeId);
        IDictionary<ActivityType, int> SumOfHoursUserSpentOnExactActivityType(int userId);

    }
}
