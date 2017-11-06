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

        public UserTypeService(UserTypeRepository userTypeRepository, UserRepository userRepository)
        {
            this.userTypeRepository = userTypeRepository;
        }

        public void Add(UserType userType)
        {
            userTypeRepository.Add(userType);
            
        }

        public UserType Get(int id)
        {
            return userTypeRepository.Get(id);
        }

        public IEnumerable<UserType> GetAll()
        {
            return userTypeRepository.GetAll();
        }

        public void Remove(int id)
        {
            userTypeRepository.Remove(id);
        }

        public void Update(UserType userType)
        {
            userTypeRepository.Update(userType);
        }
    }
}