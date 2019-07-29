using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VELogistics.Models;

namespace VELogistics.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<VELogistics.Models.Carrier> Carrier { get; set; }
        public DbSet<VELogistics.Models.Load> Load { get; set; }
        public DbSet<VELogistics.Models.Customer> Customer { get; set; }
        public DbSet<VELogistics.Models.UserType> UserType { get; set; }
        public DbSet<VELogistics.Models.User> User { get; set; }
    }
}
