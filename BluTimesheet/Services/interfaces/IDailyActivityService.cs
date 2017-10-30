using BluTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluTimesheet.Services.interfaces
{
    interface IDailyActivityService
    {
        void AddDailyActivity(DailyActivity dailyActivity);
        void RemoveDailyActivityById(int dailyActivityId);
        DailyActivity GetDailyActivityById(int dailyActivityId);
        void UpdateDailyActivity(DailyActivity dailyActivity);
        List<DailyActivity> GetActivities();
        void ApproveDailyActivity(DailyActivity dailyActivity);
    }
}
