using BluTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BluTimesheet.Controllers.interfaces
{
    public interface IUserService
    {
        void Add(User user);
        void Remove(int id);
        User Get(int id);
        void Update(User user);        
        IEnumerable<User> GetUsersByUserType(int id);
        IEnumerable<User> GetAll();
    }
}