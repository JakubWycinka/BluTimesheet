using BluTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluTimesheet.Services.interfaces
{
    public interface IActivityTypeService
    {
        void Add(ActivityType activityType);
        void Remove(int id);
        ActivityType Get(int id);
        void Update(ActivityType activityType);
        IEnumerable<ActivityType> GetAll();
    }
}
