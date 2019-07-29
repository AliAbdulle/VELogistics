using System.ComponentModel.DataAnnotations;

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

    }
}