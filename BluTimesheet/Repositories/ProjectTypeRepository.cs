﻿using BluTimesheet.Context;
using BluTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BluTimesheet.Repositories
{
    public class ProjectTypeRepository : GenericRepository<ProjectType>
    {
        
        public ProjectTypeRepository(TimesheetDbContext context) : base(context)
        {
            
        }

        
    }
}