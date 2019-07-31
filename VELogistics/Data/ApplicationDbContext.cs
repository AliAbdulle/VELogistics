using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
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
        public DbSet<Load> Load { get; set; }
        public DbSet<ApplicationUser>ApplicationUsers { get; set; }
        public DbSet<UserType> UserType { get; set; }
        public DbSet<Driver> Driver { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ApplicationUser CustomerUser = new ApplicationUser
            {
                FirstName = "Ali",
                LastName = "Abdulle",
                Name = "Jamalik",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "00000000-ffff-ffff-ffff-ffffffffffff",
                UserTypeId = 1
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            CustomerUser.PasswordHash = passwordHash.HashPassword(CustomerUser, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(CustomerUser);

            ApplicationUser CarrierUser = new ApplicationUser
            {
                FirstName = "Andy",
                LastName = "Collin",
                Name = "NSS",
                UserName = "andy@admin.com",
                NormalizedUserName = "ANDY@ADMIN.COM",
                Email = "andy@admin.com",
                NormalizedEmail = "ANDY@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434409-a4d7-48e8-9ebc-8803db794588",
                Id = "00000000-ffff-fffs-fffd-ffffffffffss",
                UserTypeId = 2
            };
             passwordHash = new PasswordHasher<ApplicationUser>();
            CarrierUser.PasswordHash = passwordHash.HashPassword(CarrierUser, "Admiw7*");
            modelBuilder.Entity<ApplicationUser>().HasData(CarrierUser);


            modelBuilder.Entity<UserType>().HasData(
                new UserType()
                {
                    Id = 1,
                    Name = "Customer"
                },
                 new UserType()
                 {
                     Id = 2,
                     Name = "Carrier"
                 }
                 );

            modelBuilder.Entity<Driver>().HasData(
              new Driver()
              {
                  Id = 1,
                  FirstName = "Liiban",
                  LastName = "Frances",
                 IsDeliverd = true

              },
               new Driver()
               {
                   Id = 2,
                   FirstName = "Chris",
                   LastName = "Morgan",
                   IsDeliverd = true
               }
               );

            modelBuilder.Entity<Load>().HasData(
              new Load()
              {
                  LoadId = 1,
                  Amount = 1200.00,
                  PickupDate = new DateTime(2019, 10, 01),
                  DeliverdDate = new DateTime(2019, 11, 01),
                  Location = "Nashville, TN",
                  DriverId = 2,
                  CustomerUserId = "Dell"

              },
               new Load()
               {
                   LoadId = 2,
                   Amount = 1000.00,
                   PickupDate = new DateTime(2019, 11, 05),
                   DeliverdDate = new DateTime(2019, 01, 11),
                   Location = "Atlanta, GA",
                   DriverId = 1,
                   CarrierUserId = "Swift"

               }
               );

        }

    }
}
