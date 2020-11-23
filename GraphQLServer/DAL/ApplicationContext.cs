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

            base.OnModelCreating(modelBuilder);
        }
    }
}
