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
        void Add(DailyActivity dailyActivity);
        void Remove(int id);
        DailyActivity Get(int id);
        void Update(DailyActivity dailyActivity);
        IEnumerable<DailyActivity> GetAll();
        void Approve(DailyActivity dailyActivity);
    }
}
