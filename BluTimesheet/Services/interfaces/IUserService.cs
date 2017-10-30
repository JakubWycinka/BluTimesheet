using BluTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BluTimesheet.Controllers.interfaces
{
    public interface IUserService
    {
        void AddUser(User user);
        void RemoveUserById(int userId);
        User GetUserById(int userId);
        void UpdateUser(User user);
        List<User> GetUsers();
        ICollection<DailyActivity> GetUserActivites(User user);
    }
}