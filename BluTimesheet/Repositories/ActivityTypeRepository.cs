using BluTimesheet.Context;
using BluTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BluTimesheet.Repositories
{
    public class ActivityTypeRepository : GenericRepository<ActivityType>
    {
       
        public ActivityTypeRepository(TimesheetDbContext context) : base(context)
        {
            
        }
    }
}