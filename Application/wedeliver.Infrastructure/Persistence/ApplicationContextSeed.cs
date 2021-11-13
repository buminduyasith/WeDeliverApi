using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wedeliver.Domain;
using wedeliver.Domain.Entities;

namespace wedeliver.Infrastructure.Persistence
{
    public class ApplicationContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext applicationContextSeed, ILogger<ApplicationContextSeed> logger)
        {
            /* if (!applicationContextSeed.Foods.Any())
             {
                 applicationContextSeed.Foods.AddRange(GetPreconfiguredOrders());
                 await applicationContextSeed.SaveChangesAsync();
                 logger.LogInformation("Seed database associated with context {DbContextName}", typeof(ApplicationDbContext).Name);
             }*/

            //if (!applicationContextSeed.FoodCategory.Any())
            //{
            //    applicationContextSeed.FoodCategory.AddRange(GetPreconfiguredOrders());
            //    await applicationContextSeed.SaveChangesAsync();
            //    logger.LogInformation("Seed database associated with context {DbContextName}", typeof(ApplicationDbContext).Name);
            //}
        }

        //private static IEnumerable<FoodCategory> GetPreconfiguredOrders()
        //{
        //    return new List<FoodCategory>
        //    {
        //        new FoodCategory() {Name="",slug, }
        //    };
        //}
    }
}
