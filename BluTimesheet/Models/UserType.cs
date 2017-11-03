using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BluTimesheet.Models
{
    public class UserType
    {
        public UserType()
        {
            User = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Role { get; set; }

        public ICollection<User> User {get; set;}

        
    }
}