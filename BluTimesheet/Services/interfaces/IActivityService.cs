using BluTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluTimesheet.Services.interfaces
{
    public interface IActivityService
    {
        void Add(Activity activity);
        void Remove(int id);
        Activity Get(int id);
        void Update(Activity activity);
        IEnumerable<Activity> GetAll();
        IEnumerable<DailyActivity> GetDailyActivities(int id);
    }
}
