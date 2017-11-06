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
            context.SaveChanges();
        }

        public User Get(int id)
        {
            return context.User.Find(id);
        }

        public void Update(User user)
        {
            var userFromDb = Get(user.Id);
            if (userFromDb != null)
            {
                userFromDb.Name = user.Name;
                userFromDb.Surname = user.Surname;
                userFromDb.UserType = user.UserType;
                userFromDb.Email = user.Email;                
                context.SaveChanges();
            }
        }

        public void ResetPassword(int id)
        {
            var userFromDb = Get(id);
            if (userFromDb != null)
            {
                userFromDb.Password = String.Empty;
                context.SaveChanges();
            }
        }

        public void SetPassword(User user)
        {
            var userFromDb = Get(user.Id);
            if (userFromDb != null)
            {
                userFromDb.Password = user.Password;
                context.SaveChanges();
            }

        }

        public void Remove(int id)
        {
            User tempUser = new User
            {
                Id = id
            };
            context.User.Remove(tempUser);
            context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return context.User.Include("UserType").AsEnumerable();
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