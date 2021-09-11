using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Domain;

namespace wedeliver.Infrastructure.Persistence
{
    public class ApplicationContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext applicationContextSeed, ILogger<ApplicationContextSeed> logger)
        {
            if (!applicationContextSeed.Foods.Any())
            {
                applicationContextSeed.Foods.AddRange(GetPreconfiguredOrders());
                await applicationContextSeed.SaveChangesAsync();
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
