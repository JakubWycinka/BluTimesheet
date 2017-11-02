using System;
using System.ComponentModel.DataAnnotations;

namespace BluTimesheet.Models
{
    public class DailyActivity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Begining { get; set; }
        public DateTime End { get; set; }
        public Activity Activity { get; set; }
        public Project Project { get; set; }
        public bool ApprovedByManager { get; set; }
        


    }
}