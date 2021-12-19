using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using wedeliver.Application.Contracts.Persisternce;
using wedeliver.Domain;
using wedeliver.Domain.Common;
using wedeliver.Domain.Entities;

namespace wedeliver.Infrastructure.Persistence
{
    public class ApplicationDbContext:IdentityDbContext, IApplicationDbContext
    //DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information)
                .EnableDetailedErrors();
        }
   

        public DbSet<Food> Foods { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Rider> Riders { get; set; }
        public DbSet<Ratings> Ratings { get; set; }
        public DbSet<FoodOrder> FoodOrder { get; set; }
        public DbSet<FoodOrderDetails> FoodOrderDetails { get; set; }
        public DbSet<MedicineOrder> MedicineOrders { get; set; }
        public DbSet<FoodCategory> FoodCategory { get; set; }
        public DbSet<RestaurantFoodCategoryMap> RestaurantFoodCategoryMap { get; set; }
        public DbSet<ShippingDetails> ShippingDetails { get; set; }
        public DbSet<RestaurantRating> RestaurantRating { get; set; }
        public DbSet<StoreOpenTimes> StoreOpenTimes { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

           

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreateDate = DateTime.Now;
                        
                       
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
