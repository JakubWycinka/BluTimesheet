using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BluTimesheet.Models
{
    public class ProjectType
    {
        public ProjectType()
        {
            Project = new HashSet<Project>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<Project> Project { get; set; }
    }
}