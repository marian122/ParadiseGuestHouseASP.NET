using Microsoft.EntityFrameworkCore;
using ParadiseGuestHouse.Data;
using ParadiseGuestHouse.Data.Models;
using ParadiseGuestHouse.Data.Models.Enums;
using ParadiseGuestHouse.Data.Repositories;
using ParadiseGuestHouse.Services.Data;
using ParadiseGuestHouse.Services.Mapping;
using ParadiseGuestHouse.Web.InputModels.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParadiseGuestHouse.Services.Tests
{
    public class RestaurantServiceTests
    {
        private ApplicationDbContext dbContext;
        private RestaurantsService restaurantsService;

        public class MyTestRestaurant : IMapFrom<Restaurant>
        {
            public string Id { get; set; }
        }

        [Fact]
        public async Task Check_Restaurant_Seeder()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(Guid.NewGuid().ToString())
                          .Options;

            this.dbContext = new ApplicationDbContext(options);

            var restaurantRepository = new EfDeletableEntityRepository<Restaurant>(this.dbContext);
            var restaurantReservationRepository = new EfDeletableEntityRepository<RestaurantReservation>(this.dbContext);

            restaurantRepository.AddAsync(new Restaurant
            {
                Id = "restaurantid",
                CurrentCapacity = 100,
                MaxCapacity = 100,
                Description = "restaurant",
                Price = 50,
                Title = "restaurant",
            }).GetAwaiter().GetResult();

            restaurantRepository.SaveChangesAsync().GetAwaiter().GetResult();

            this.restaurantsService = new RestaurantsService(restaurantRepository, restaurantReservationRepository);

            AutoMapperConfig.RegisterMappings(typeof(MyTestRestaurant).Assembly);

            var actualResult = restaurantRepository.All().ToList();

            int expectedResult = 1;
            Assert.Equal(actualResult.Count(), expectedResult);
        }

        [Fact]
        public async Task Reserve_Restaurant_Should_Make_One_Reservation()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(Guid.NewGuid().ToString())
                          .Options;

            this.dbContext = new ApplicationDbContext(options);

            var restaurantRepository = new EfDeletableEntityRepository<Restaurant>(this.dbContext);
            var restaurantReservationRepository = new EfDeletableEntityRepository<RestaurantReservation>(this.dbContext);

            restaurantRepository.AddAsync(new Restaurant
            {
                Id = "restaurantid",
                CurrentCapacity = 100,
                MaxCapacity = 100,
                Description = "restaurant",
                Price = 50,
                Title = "restaurant",
            }).GetAwaiter().GetResult();

            restaurantRepository.SaveChangesAsync().GetAwaiter().GetResult();

            this.restaurantsService = new RestaurantsService(restaurantRepository, restaurantReservationRepository);

            AutoMapperConfig.RegisterMappings(typeof(MyTestRestaurant).Assembly);

            var reservation = new RestaurantInputModel
            {
                EventDate = DateTime.Now.AddDays(1),
                CheckIn = DateTime.Now.AddDays(1).AddHours(10),
                CheckOut = DateTime.Now.AddDays(1).AddHours(11),
                NumberOfGuests = 50,
                EmailAddress = "maleksiev12@gmail.com",
                FirstName = "Marian",
                LastName = "Kyuchukov",
                PhoneNumber = "0888186978",
                EventType = (RestaurantEventType)Enum.Parse(typeof(RestaurantEventType), "Birthday"),
            };

            var actualResult = await this.restaurantsService.ReserveRestaurant(reservation);

            Assert.True(actualResult);
        }

        [Fact]
        public async Task Reserve_Restaurant_Should_Reserve_For_Choosen_Guests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(Guid.NewGuid().ToString())
                          .Options;

            this.dbContext = new ApplicationDbContext(options);

            var restaurantRepository = new EfDeletableEntityRepository<Restaurant>(this.dbContext);
            var restaurantReservationRepository = new EfDeletableEntityRepository<RestaurantReservation>(this.dbContext);

            restaurantRepository.AddAsync(new Restaurant
            {
                Id = "restaurantid",
                CurrentCapacity = 100,
                MaxCapacity = 100,
                Description = "restaurant",
                Price = 50,
                Title = "restaurant",
            }).GetAwaiter().GetResult();

            restaurantRepository.SaveChangesAsync().GetAwaiter().GetResult();

            this.restaurantsService = new RestaurantsService(restaurantRepository, restaurantReservationRepository);

            AutoMapperConfig.RegisterMappings(typeof(MyTestRestaurant).Assembly);

            var reservation = new RestaurantInputModel
            {
                EventDate = DateTime.Now.AddDays(1),
                CheckIn = DateTime.Now.AddDays(1).AddHours(10),
                CheckOut = DateTime.Now.AddDays(1).AddHours(11),
                NumberOfGuests = 50,
                EmailAddress = "maleksiev12@gmail.com",
                FirstName = "Marian",
                LastName = "Kyuchukov",
                PhoneNumber = "0888186978",
                EventType = (RestaurantEventType)Enum.Parse(typeof(RestaurantEventType), "Birthday"),
            };

            var result = await this.restaurantsService.ReserveRestaurant(reservation);

            var parsedEventType = (RestaurantEventType)Enum.Parse(typeof(RestaurantEventType), "Birthday");

            var actualResult = restaurantReservationRepository.All().FirstOrDefault(x => x.EventType == parsedEventType).NumberOfGuests;

            var expected = 50;

            Assert.Equal(expected, actualResult);
        }

        [Fact]
        public async Task Reserve_Restaurant_Should_Reserve_Correct_EventType()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(Guid.NewGuid().ToString())
                          .Options;

            this.dbContext = new ApplicationDbContext(options);

            var restaurantRepository = new EfDeletableEntityRepository<Restaurant>(this.dbContext);
            var restaurantReservationRepository = new EfDeletableEntityRepository<RestaurantReservation>(this.dbContext);

            restaurantRepository.AddAsync(new Restaurant
            {
                Id = "restaurantid",
                CurrentCapacity = 100,
                MaxCapacity = 100,
                Description = "restaurant",
                Price = 50,
                Title = "restaurant",
            }).GetAwaiter().GetResult();

            restaurantRepository.SaveChangesAsync().GetAwaiter().GetResult();

            this.restaurantsService = new RestaurantsService(restaurantRepository, restaurantReservationRepository);

            AutoMapperConfig.RegisterMappings(typeof(MyTestRestaurant).Assembly);

            restaurantReservationRepository.AddAsync(new RestaurantReservation
            {
                EventDate = DateTime.Now.AddDays(1),
                CheckIn = DateTime.Now.AddDays(1).AddHours(10),
                CheckOut = DateTime.Now.AddDays(1).AddHours(11),
                NumberOfGuests = 50,
                PhoneNumber = "0888186978",
                EventType = (RestaurantEventType)Enum.Parse(typeof(RestaurantEventType), "Birthday"),
            }).GetAwaiter().GetResult();

            restaurantReservationRepository.SaveChangesAsync().GetAwaiter().GetResult();

            var actualResult = restaurantReservationRepository.All().First().EventType.ToString();

            var expected = "Birthday";

            Assert.Equal(expected, actualResult);
        }
    }
}
