﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VELogistics.Models
{
    public class User
    {
        
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        [Display(Name = "User Type")]
        public int UserTypeId { get; set; }
        [Required]
        public UserType UserType { get; set; }

    }
}
