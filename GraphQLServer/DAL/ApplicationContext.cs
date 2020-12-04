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
        public virtual DbSet<ItemOrder> ItemOrder { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Make SKU number unique to insure no duplicates.
            // -- Note: Avoid making SKU a primary key since its a natural key, which could change.
            modelBuilder.Entity<Product>(entity => {
                entity.HasIndex(e => e.SKU).IsUnique();
            });

            //Seed some item orders
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    Description = "Elder Wand",
                    SKU = "EW02112152",
                    MethodOfShipment = "UPS",
                    Inventory = 1000,
                    Buffer = 20,
                },
                new Product()
                {
                    Id = 2,
                    Description = "Philosophy 101",
                    SKU = "PH02112101",
                    MethodOfShipment = "UPS",
                    Inventory = 200,
                    Buffer = 10,
                },
                new Product()
                {
                    Id = 3,
                    Description = "Cookie Dough",
                    SKU = "CD02112613",
                    MethodOfShipment = "UPS",
                    Inventory = 600,
                    Buffer = 10,
                }
             );

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
                    FirstName = "Albus",
                    LastName = "Dumbledore",
                    Address1 = "6000 Universal Blvd",
                    City = "Orlando",
                    State = "FL",
                    PostalCode = "32819",
                    CountryCode = "USA",
                    Email = "AlbusD@hogwarts.com",
                    Phone = "6125555555",
                    Status = "PENDING"
                }
                );

            modelBuilder.Entity<ItemOrder>().HasData(
                new ItemOrder()
                {
                    Id = 1,
                    SubmissionId = 2,
                    ProductId = 2,
                    QTY = 5,
                    ShippedDateTime = DateTime.Now,
                    TrackingNumber = "1Z204E380338943508"
                },
                new ItemOrder()
                {
                    Id = 2,
                    SubmissionId = 2,
                    ProductId = 1,
                    QTY = 3,
                    ShippedDateTime = DateTime.Now,
                    TrackingNumber = "1Z204E380338943508"
                },
                new ItemOrder()
                {
                    Id = 3,
                    SubmissionId = 2,
                    ProductId = 3,
                    QTY = 7,
                    ShippedDateTime = DateTime.Now,
                    TrackingNumber = "1Z204E380338943587"
                },
                new ItemOrder()
                {
                    Id = 4,
                    SubmissionId = 3,
                    ProductId = 2,
                    QTY = 5,
                    ShippedDateTime = DateTime.Now,
                    TrackingNumber = "1Z204E380338945687"
                },
                new ItemOrder()
                {
                    Id = 5,
                    SubmissionId = 3,
                    ProductId = 1,
                    QTY = 10,
                    ShippedDateTime = DateTime.Now,
                    TrackingNumber = "1Z204E380338945687"
                },
                new ItemOrder()
                {
                    Id = 6,
                    SubmissionId = 1,
                    ProductId = 3,
                    QTY = 2,
                    ShippedDateTime = DateTime.Now,
                    TrackingNumber = "1Z204E380338945987"
                }
             );

            base.OnModelCreating(modelBuilder);
        }
    }
}
