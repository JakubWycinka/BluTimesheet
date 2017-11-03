using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BluTimesheet.Models
{
    public class Activity
    {
        public Activity()
        {
            DailyActivity = new HashSet<DailyActivity>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<DailyActivity> DailyActivity { get; set; }
    }
}