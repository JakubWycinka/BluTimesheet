using BluTimesheet.Context;
using BluTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BluTimesheet.Repositories
{
    public class UserTypeRepository : IDisposable
    {
        private TimesheetDbContext context;

        public UserTypeRepository(TimesheetDbContext context)
        {
            this.context = context;
        }

        public void Add(UserType userType)
        {
            context.UserType.Add(userType);
            context.SaveChanges();
        }

        public UserType Get(int id)
        {
            return context.UserType.Find(id);
        }

        public void Remove(int id)
        {
            UserType tempUserType = new UserType
            {
                Id = id
            };
            context.UserType.Remove(tempUserType);
            context.SaveChanges();
        }

        public void Update(UserType userType)
        {
            var userTypeFromDb = context.UserType.SingleOrDefault(userTypeInDb => userTypeInDb.Id == userType.Id);
            if (userTypeFromDb != null)
            {

                userTypeFromDb.Role = userType.Role;
                context.SaveChanges();
            }

        }

        public IEnumerable<UserType> GetAll()
        {
            return context.UserType.AsEnumerable<UserType>();
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