using BluTimesheet.Context;
using BluTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BluTimesheet.Repositories
{
    public class UserRepository
    {
        private readonly TimesheetDbContext context;

        public UserRepository(TimesheetDbContext context)
        {
            this.context = context;
        }

        public void AddUser(User user)
        {
            context.User.Add(user);
        }

        public User GetUserById(int userId)
        {
            return context.User.Find(userId);
        }

        public void UpdateUser(User user)
        {
            var userFromDb = context.User.SingleOrDefault(userInDb => userInDb.Id == user.Id);
            if (userFromDb != null)
            {
                userFromDb.Name = user.Name;
                userFromDb.Surname = user.Surname;
                userFromDb.UserType = user.UserType;
                userFromDb.AllDailyActivities = user.AllDailyActivities;
                userFromDb.Email = user.Email;                
                context.SaveChanges();
            }
        }

        public void RemoveUserById(int userId)
        {
            User tempUser = new User
            {
                Id = userId
            };
            context.User.Remove(tempUser);
        }

        public ICollection<DailyActivity> GetUserActivities(User user)
        {
          
            return context.User.Find(user).AllDailyActivities;

        }

        public List<User> GetUsers()
        {
            return context.User.ToList();
        }

    }
}