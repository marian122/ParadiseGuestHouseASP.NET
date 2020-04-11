﻿namespace ParadiseGuestHouse.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using ParadiseGuestHouse.Data.Models;

    public class RestaurantSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Restaurants.Any())
            {
                return;
            }

            await dbContext.Restaurants.AddAsync(new Restaurant
            {
                Id = "restaurantid",
                CreatedOn = DateTime.UtcNow,
                CurrentCapacity = 100,
                MaxCapacity = 100,
                IsDeleted = false,
                Description = "Restaurant",
                Price = 50,
                Title = "Restaurant",
            });
        }
    }
}
