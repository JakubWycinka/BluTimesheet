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
        void AddUserType(UserType userType);
        void RemoveUserTypeById(int userTypeId);
        UserType GetUserTypeById(int userTypeId);
        void UpdateUserType(UserType userType);
        List<UserType> GetUserTypes();
    }
}
