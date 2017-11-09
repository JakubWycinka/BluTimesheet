using BluTimesheet.Context;
using BluTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BluTimesheet.Repositories
{
    public class UserTypeRepository : GenericRepository<UserType>
    {

        public UserTypeRepository(TimesheetDbContext context) : base(context)
        {
            
        }
    }
}