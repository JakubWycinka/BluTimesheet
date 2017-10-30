using BluTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluTimesheet.Services.interfaces
{
    interface IActivityService
    {
        void AddActivity(Activity activity);
        void RemoveActivityById(int activityId);
        Activity GetActivityById(int activityId);
        void UpdateActivity(Activity activity);
        List<Activity> GetActivities();
    }
}
