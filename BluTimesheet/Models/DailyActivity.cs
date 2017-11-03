using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BluTimesheet.Models
{
    public class DailyActivity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Begining { get; set; }
        public DateTime End { get; set; }
        [ForeignKey("Id")]
        public Activity Activity { get; set; }
        [ForeignKey("Id")]
        public Project Project { get; set; }
        public bool ApprovedByManager { get; set; }
        


    }
}