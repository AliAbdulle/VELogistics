using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VELogistics.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LasstName { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int CarrierId { get; set; }
        [Required]
        public Carrier Carrier { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Load> Loads { get; set; }

        public Customer()
        {
            Active = true;
        }




    }
}
