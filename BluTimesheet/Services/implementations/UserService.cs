using System.Collections.Generic;
using BluTimesheet.Controllers.interfaces;
using BluTimesheet.Models;
using BluTimesheet.Repositories;

namespace BluTimesheet.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository userRepository;

        public UserService(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void Add(User user)
        {
            userRepository.Add(user);
        }

        public IEnumerable<DailyActivity> GetUserActivites(User user)
        {
            return userRepository.GetUserActivities(user);
        }
        
        public User Get(int userId)
        {
            return userRepository.Get(userId);
        }

        public IEnumerable<User> GetAll()
        {
            return userRepository.GetAll();
        }

        public void Remove(int userId)
        {
            userRepository.Remove(userId);
        }

        public void Update(User user)
        {
            userRepository.Update(user);
        }

        
    }
}