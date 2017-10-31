using BluTimesheet.Context;
using BluTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BluTimesheet.Repositories
{
    public class UserRepository : IDisposable
    {
        private TimesheetDbContext context;

        public UserRepository(TimesheetDbContext context)
        {
            this.context = context;
        }

        public void Add(User user)
        {
            context.User.Add(user);
        }

        public User Get(int userId)
        {
            return context.User.Find(userId);
        }

        public void Update(User user)
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

        public void Remove(int userId)
        {
            User tempUser = new User
            {
                Id = userId
            };
            context.User.Remove(tempUser);
        }

        public IEnumerable<DailyActivity> GetUserActivities(User user)
        {
          
            return context.User.Find(user).AllDailyActivities;

        }

        public IEnumerable<User> GetAll()
        {
            return context.User.AsEnumerable<User>();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (context != null)
                {
                    context.Dispose();
                    context = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}