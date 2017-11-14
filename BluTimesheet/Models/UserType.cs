using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
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
        [Key]
        public int Id { get; set; }
        [Required]
        public string Role { get; set; }
    }
}