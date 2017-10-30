﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BluTimesheet.Models
{
    public class UserType
    {
        [Key]
        public int Id { get; set; }
        public string Role { get; set; }
    }
}