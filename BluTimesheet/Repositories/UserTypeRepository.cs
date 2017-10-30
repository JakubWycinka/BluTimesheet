using BluTimesheet.Context;
using BluTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BluTimesheet.Repositories
{
    public class UserTypeRepository
    {
        private readonly TimesheetDbContext context;

        public UserTypeRepository(TimesheetDbContext context)
        {
            this.context = context;
        }

        public void Add(UserType userType)
        {
            context.UserType.Add(userType);
        }

        public UserType GetById(int userTypeId)
        {
            return context.UserType.Find(userTypeId);
        }

        public void RemoveById(int userTypeId)
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

        public List<UserType> GetUserTypes()
        {
            return context.UserType.ToList();
        }
    }
}