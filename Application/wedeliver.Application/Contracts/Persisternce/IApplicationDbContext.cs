using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using wedeliver.Domain;
using wedeliver.Domain.Entities;

namespace wedeliver.Application.Contracts.Persisternce
{
    public interface IApplicationDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        DbSet<TModel> Set<TModel>() where TModel : class;
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




    }
}
