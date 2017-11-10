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

        public User Get(int id)
        {
            return userRepository.Get(id);
        }

        public IEnumerable<User> GetAll()
        {
            return userRepository.GetAll();
        }

        public void Remove(int id)
        {
            userRepository.Remove(id);
        }

        public void Update(User user)
        {
            userRepository.Update(user);
        }

        public IEnumerable<User> GetUsersByUserType(int id)
        {
            return userRepository.Search(x => x.UserType.Id == id);
        }

    }
}