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
        void Add(Activity activity);
        void Remove(int activityId);
        Activity Get(int activityId);
        void Update(Activity activity);
        IEnumerable<Activity> GetAll();
    }
}
