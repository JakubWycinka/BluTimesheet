﻿using BluTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BluTimesheet.Controllers.interfaces
{
    public interface IUserService
    {
        void Add(User user);
        void Remove(int userId);
        User Get(int userId);
        void Update(User user);
        IEnumerable<User> GetAll();
        IEnumerable<DailyActivity> GetUserActivites(User user);
    }
}