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
        private readonly UserRepository userRepository;

        public UserTypeService(UserTypeRepository userTypeRepository, UserRepository userRepository)
        {
            this.userTypeRepository = userTypeRepository;
            this.userRepository = userRepository;
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

        public IEnumerable<User> GetUsers(int id)
        {
            return userRepository.GetAll().Where(x => x.UserType == Get(id));
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