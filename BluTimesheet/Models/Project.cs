using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BluTimesheet.Models
{
    public class Project 
    {
        public Project()
        {
            DailyActivity = new HashSet<DailyActivity>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ProjectType ProjectType { get; set; }

        public ICollection<DailyActivity> DailyActivity { get; set; }
    }
}