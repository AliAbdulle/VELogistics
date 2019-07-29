using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VELogistics.Models
{
    public class Carrier
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        public int DriverId { get; set; }
        [Required]
        public Driver Driver { get; set; }

        public virtual ICollection<Load> Loads { get; set; }




    }
}