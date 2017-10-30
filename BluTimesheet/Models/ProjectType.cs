using System.ComponentModel.DataAnnotations;

namespace BluTimesheet.Models
{
    public class ProjectType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}