using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Domain;

namespace wedeliver.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if (!orderContext.Foods.Any())
            {
                orderContext.Foods.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(ApplicationDbContext).Name);
            }
        }

        private static IEnumerable<Food> GetPreconfiguredOrders()
        {
            return new List<Food>
            {
                new Food() {Name="chicken rice",Discription="chicken rice 1",Price=250.45 }
            };
        }
    }
}
