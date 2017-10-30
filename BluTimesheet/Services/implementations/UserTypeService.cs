using BluTimesheet.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BluTimesheet.Models;
using BluTimesheet.Repositories;

namespace BluTimesheet.Services.implementations
{
    public class UserTypeService : IUserTypeService
    {
        private readonly UserTypeRepository userTypeRepository;

        public UserTypeService(UserTypeRepository userTypeRepository)
        {
            this.userTypeRepository = userTypeRepository;
        }

        public void AddUserType(UserType userType)
        {
            userTypeRepository.Add(userType);
            
        }

        public UserType GetUserTypeById(int userTypeId)
        {
            return userTypeRepository.GetById(userTypeId);
        }

        public List<UserType> GetUserTypes()
        {
            return userTypeRepository.GetUserTypes();
        }

        public void RemoveUserTypeById(int userTypeId)
        {
            userTypeRepository.RemoveById(userTypeId);
        }

        public void UpdateUserType(UserType userType)
        {
            userTypeRepository.Update(userType);
        }
    }
}