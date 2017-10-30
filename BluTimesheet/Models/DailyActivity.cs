using System;
using System.ComponentModel.DataAnnotations;

namespace BluTimesheet.Models
{
    public class DailyActivity
    {
        [Key]
        public int Id { get; set; }
        public int BeginingHour { get; set; }
        public int BeginingMinute { get; set; }
        public int EndingHour { get; set; }
        public int EndingMinute { get; set; }
        public DateTime Date { get; set; }
        public Activity Activity { get; set; }
        public Project Project { get; set; }
        public bool ApprovedByManager { get; set; }
        


    }
}