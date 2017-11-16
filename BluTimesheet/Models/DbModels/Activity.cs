using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BluTimesheet.Models.DbModels
{
    public class Activity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime? Begining { get; set; }

        public DateTime? End { get; set; }

        [Required]
        public virtual ActivityType ActivityType { get; set; }
          
        public virtual Project Project { get; set; }

        public bool ApprovedByManager { get; set; }

        [Required]
        public string UserId { get; set; }

        


    }
}