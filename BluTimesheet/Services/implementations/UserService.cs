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

        public void AddUser(User user)
        {
            userRepository.AddUser(user);
        }

        public ICollection<DailyActivity> GetUserActivites(User user)
        {
            return userRepository.GetUserActivities(user);
        }
        
        public User GetUserById(int userId)
        {
            return userRepository.GetUserById(userId);
        }

        public List<User> GetUsers()
        {
            return userRepository.GetUsers();
        }

        public void RemoveUserById(int userId)
        {
            userRepository.RemoveUserById(userId);
        }

        public void UpdateUser(User user)
        {
            userRepository.UpdateUser(user);
        }

        
    }
}