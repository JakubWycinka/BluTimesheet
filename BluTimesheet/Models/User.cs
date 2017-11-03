using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BluTimesheet.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }

        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [ForeignKey("Id")]
        public UserType UserType { get; set; }

        public ICollection<DailyActivity> DailyActivities { get; set; }
    }      
}