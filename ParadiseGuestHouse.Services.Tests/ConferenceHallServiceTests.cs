using Microsoft.EntityFrameworkCore;
using ParadiseGuestHouse.Data;
using ParadiseGuestHouse.Data.Models;
using ParadiseGuestHouse.Data.Models.Enums;
using ParadiseGuestHouse.Data.Repositories;
using ParadiseGuestHouse.Services.Data;
using ParadiseGuestHouse.Services.Mapping;
using ParadiseGuestHouse.Web.InputModels.ConferenceHall;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParadiseGuestHouse.Services.Tests
{
    [Collection(nameof(MapperFixture))]
    public class ConferenceHallServiceTests
    {
        private ApplicationDbContext dbContext;
        private ConferenceHallService conferenceHallService;

        public class MyTestConferenceHall : IMapFrom<ConferenceHall>
        {
            public string Id { get; set; }
        }

        [Fact]
        public async Task Check_ConferenceHall_Seeder()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(Guid.NewGuid().ToString())
                          .Options;

            this.dbContext = new ApplicationDbContext(options);

            var conferenceHallRepository = new EfDeletableEntityRepository<ConferenceHall>(this.dbContext);
            var conferenceHallReservationRepository = new EfDeletableEntityRepository<ConferenceHallReservation>(this.dbContext);

            await conferenceHallRepository.AddAsync(new ConferenceHall
            {
                Id = "conferenceid",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
                EventType = (ConfHallEventType)Enum.Parse(typeof(ConfHallEventType), "Conference"),
                Description = "Conference",
                CurrentCapacity = 100,
                MaxCapacity = 100,
                Price = 50,
            });

            conferenceHallRepository.SaveChangesAsync().GetAwaiter().GetResult();

            this.conferenceHallService = new ConferenceHallService(conferenceHallReservationRepository, conferenceHallRepository);

            var actualResult = conferenceHallRepository.All().ToList();

            int expectedResult = 1;
            Assert.Equal(actualResult.Count(), expectedResult);
        }


        [Fact]
        public async Task Reserve_ConferenceHall_Should_Make_One_Reservation()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(Guid.NewGuid().ToString())
                          .Options;

            this.dbContext = new ApplicationDbContext(options);

            var conferenceHallRepository = new EfDeletableEntityRepository<ConferenceHall>(this.dbContext);
            var conferenceHallReservationRepository = new EfDeletableEntityRepository<ConferenceHallReservation>(this.dbContext);

            await conferenceHallRepository.AddAsync(new ConferenceHall
            {
                Id = "conferenceid",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
                EventType = (ConfHallEventType)Enum.Parse(typeof(ConfHallEventType), "Conference"),
                Description = "Conference",
                CurrentCapacity = 100,
                MaxCapacity = 100,
                Price = 50,
            });

            await conferenceHallRepository.SaveChangesAsync();

            this.conferenceHallService = new ConferenceHallService(conferenceHallReservationRepository, conferenceHallRepository);

            var reservation = new ConferenceHallInputModel
            {
                EventDate = DateTime.Now.AddDays(1),
                CheckIn = DateTime.Now.AddDays(1).AddHours(10),
                CheckOut = DateTime.Now.AddDays(1).AddHours(11),
                NumberOfGuests = 50,
                EmailAddress = "maleksiev12@gmail.com",
                FirstName = "Marian",
                LastName = "Kyuchukov",
                PhoneNumber = "0888186978",
                EventType = (ConfHallEventType)Enum.Parse(typeof(ConfHallEventType), "Conference"),
            };

            var actualResult = await this.conferenceHallService.ReserveConferenceHall(reservation);

            Assert.True(actualResult);
        }

        [Fact]
        public async Task Reserve_ConferenceHall_Should_Decrease_Halls_Capacity()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(Guid.NewGuid().ToString())
                          .Options;

            this.dbContext = new ApplicationDbContext(options);

            var conferenceHallRepository = new EfDeletableEntityRepository<ConferenceHall>(this.dbContext);
            var conferenceHallReservationRepository = new EfDeletableEntityRepository<ConferenceHallReservation>(this.dbContext);

            await conferenceHallRepository.AddAsync(new ConferenceHall
            {
                Id = "conferenceid",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
                EventType = (ConfHallEventType)Enum.Parse(typeof(ConfHallEventType), "Conference"),
                Description = "Conference",
                CurrentCapacity = 100,
                MaxCapacity = 100,
                Price = 50,
            });

            await conferenceHallRepository.SaveChangesAsync();

            this.conferenceHallService = new ConferenceHallService(conferenceHallReservationRepository, conferenceHallRepository);

            var reservation = new ConferenceHallInputModel
            {
                EventDate = DateTime.Now.AddDays(1),
                CheckIn = DateTime.Now.AddDays(1).AddHours(10),
                CheckOut = DateTime.Now.AddDays(1).AddHours(11),
                NumberOfGuests = 50,
                EmailAddress = "maleksiev12@gmail.com",
                FirstName = "Marian",
                LastName = "Kyuchukov",
                PhoneNumber = "0888186978",
                EventType = (ConfHallEventType)Enum.Parse(typeof(ConfHallEventType), "Conference"),
            };

            var result = await this.conferenceHallService.ReserveConferenceHall(reservation);

            var parsedEventType = (ConfHallEventType)Enum.Parse(typeof(ConfHallEventType), "Conference");

            var actualResult = conferenceHallRepository.All().FirstOrDefault(x => x.EventType == parsedEventType).CurrentCapacity;

            var expected = 50;

            Assert.Equal(expected, actualResult);
        }

        [Fact]
        public async Task Reserve_ConferenceHall_Should_Reserve_Correctly_EventType()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(Guid.NewGuid().ToString())
                          .Options;

            this.dbContext = new ApplicationDbContext(options);

            var conferenceHallRepository = new EfDeletableEntityRepository<ConferenceHall>(this.dbContext);
            var conferenceHallReservationRepository = new EfDeletableEntityRepository<ConferenceHallReservation>(this.dbContext);

            await conferenceHallRepository.AddAsync(new ConferenceHall
            {
                Id = "conferenceid",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
                EventType = (ConfHallEventType)Enum.Parse(typeof(ConfHallEventType), "TeamBuilding"),
                Description = "TeamBuilding",
                CurrentCapacity = 100,
                MaxCapacity = 100,
                Price = 50,
            });

            await conferenceHallRepository.SaveChangesAsync();

            this.conferenceHallService = new ConferenceHallService(conferenceHallReservationRepository, conferenceHallRepository);

            conferenceHallReservationRepository.AddAsync(new ConferenceHallReservation
            {
                EventDate = DateTime.Now,
                CheckIn = DateTime.Now.AddHours(2),
                CheckOut = DateTime.Now.AddHours(3),
                NumberOfGuests = 50,
                PhoneNumber = "0888186978",
                EventType = (ConfHallEventType)Enum.Parse(typeof(ConfHallEventType), "TeamBuilding"),
                ConferenceHallId = "conferenceid",
            }).GetAwaiter().GetResult();

            await conferenceHallReservationRepository.SaveChangesAsync();

            var actualResult = conferenceHallReservationRepository.All().FirstOrDefault(x => x.ConferenceHallId == "conferenceid").EventType.ToString();

            var expected = "TeamBuilding";

            Assert.Equal(expected, actualResult);
        }
    }
}
