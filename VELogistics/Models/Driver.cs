using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VELogistics.Models
{
    public class Driver
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public bool IsDeliverd { get; set; }

        public Driver ()
        {
            IsDeliverd = true;
        }
        [NotMapped]
        [Display(Name= "FullName")]
        public string FullName => $"{FirstName} {LastName}";

        //public List<Load> Loads { get; set; }

    }
}