using GraphQLServer.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLServer.DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public virtual DbSet<Submission> Submission { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductOrder> ProductOrder { get; set; }
        public virtual DbSet<TrackingInformation> TrackingInformation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Make SKU number unique to insure no duplicates.
            // -- Note: Avoid making SKU a primary key since its a natural key, which could change.
            modelBuilder.Entity<Product>(entity => {
                entity.HasIndex(e => e.SKU).IsUnique();
            });

            //Seed some submissions
            modelBuilder.Entity<Submission>().HasData(
                new Submission()
                {
                    Id = 1,
                    ClientSubmissionId = "4564123456789456",
                    DateTime = DateTime.Now,
                    FirstName = "John",
                    LastName = "Doe",
                    Address1 = "1175 S Pokegama Ave",
                    City = "Grand Rapids",
                    State = "MN",
                    PostalCode = "55744",
                    CountryCode = "USA",
                    Email = "culvers@example.com",
                    Phone = "6125555555",
                    Status = "PENDING"
                },
                new Submission()
                {
                    Id = 2,
                    ClientSubmissionId = "7893541231456654",
                    DateTime = DateTime.Now,
                    FirstName = "Alan",
                    LastName = "Watts",
                    Address1 = "239 Vauxhall Bridge Rd",
                    City = "London",
                    State = "",
                    PostalCode = "SO40 9RB",
                    CountryCode = "GBR",
                    Email = "alan@example.com",
                    Phone = "6125555555",
                    Status = "PENDING"
                },
                new Submission()
                {
                    Id = 3,
                    ClientSubmissionId = "7893541231456654",
                    DateTime = DateTime.Now,
                    FirstName = "Harry",
                    LastName = "Potter",
                    Address1 = "6000 Universal Blvd",
                    City = "Orlando",
                    State = "FL",
                    PostalCode = "32819",
                    CountryCode = "USA",
                    Email = "harrypotter@hogwarts.com",
                    Phone = "6125555555",
                    Status = "PENDING"
                }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
