using BluTimesheet.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace BluTimesheet.Utils
{
    public class Helper
    {
        public static async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType, User user)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(user, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}