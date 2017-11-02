using BluTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BluTimesheet.Controllers.interfaces
{
    public interface IUserService
    {
        void Add(User user);
        void Remove(int id);
        User Get(int id);
        void Update(User user);
        IEnumerable<User> GetAll();
        IEnumerable<DailyActivity> GetUserActivites(User user);
        void SetPassword(User user);
        void ResetPassword(int id);
    }
}