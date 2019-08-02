using System;
using System.ComponentModel.DataAnnotations;

namespace VELogistics.Models
{
    public class Load
    {
        public int LoadId { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public DateTime PickupDate { get; set; }
        [Required]
        public DateTime DeliverdDate { get; set; }
        [Required]
        public string Location { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
        public int UserTypeId { get; set; }
        public UserType UserType { get; set; }

    }
}