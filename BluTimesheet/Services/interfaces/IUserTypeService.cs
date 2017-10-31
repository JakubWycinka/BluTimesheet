using BluTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluTimesheet.Services.interfaces
{
    interface IUserTypeService
    {
        void Add(UserType userType);
        void Remove(int userTypeId);
        UserType Get(int userTypeId);
        void Update(UserType userType);
        IEnumerable<UserType> GetAll();
    }
}
