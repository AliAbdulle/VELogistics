using System;
using System.ComponentModel.DataAnnotations;

namespace VELogistics.Models
{
    public class Load
    {
        public int LoadId { get; set; }
        [Required]
        public string Customer { get; set; }
        [Required]
        public string Carrier { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public DateTime PickupDate { get; set; }
        [Required]
        public DateTime DeliverdDate { get; set; }
        [Required]
        public string Location { get; set; }
        public int DriverId { get; set; }
        [Required]
        public int UserId { get; set; }

    }
}