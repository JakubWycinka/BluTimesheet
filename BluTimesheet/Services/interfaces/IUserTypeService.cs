using BluTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluTimesheet.Services.interfaces
{
    public interface IUserTypeService
    {
        void Add(UserType userType);
        void Remove(int id);
        UserType Get(int id);
        void Update(UserType userType);
        IEnumerable<UserType> GetAll();
        IEnumerable<User> GetUsers(int id);
    }
}
