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
        }

        public UserType Get(int userTypeId)
        {
            return context.UserType.Find(userTypeId);
        }

        public void Remove(int userTypeId)
        {
            UserType tempUserType = new UserType
            {
                Id = userTypeId
            };
            context.UserType.Remove(tempUserType);
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