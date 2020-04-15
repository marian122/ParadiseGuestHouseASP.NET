using Microsoft.EntityFrameworkCore;
using ParadiseGuestHouse.Data;
using ParadiseGuestHouse.Data.Models;
using ParadiseGuestHouse.Data.Models.Enums;
using ParadiseGuestHouse.Data.Repositories;
using ParadiseGuestHouse.Services.Data;
using ParadiseGuestHouse.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParadiseGuestHouse.Services.Tests
{
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

            conferenceHallRepository.AddAsync(new ConferenceHall
            {
                Id = "conferenceid",
                CreatedOn = DateTime.UtcNow,
                IsDeleted = false,
                EventType = (ConfHallEventType)Enum.Parse(typeof(ConfHallEventType), "Conference"),
                Description = "Conference",
                CurrentCapacity = 100,
                MaxCapacity = 100,
                Price = 50,
            }).GetAwaiter().GetResult();

            conferenceHallRepository.SaveChangesAsync().GetAwaiter().GetResult();

            this.conferenceHallService = new ConferenceHallService(conferenceHallReservationRepository, conferenceHallRepository);

            AutoMapperConfig.RegisterMappings(typeof(MyTestConferenceHall).Assembly);

            var actualResult = conferenceHallRepository.All().ToList();

            int expectedResult = 1;
            Assert.Equal(actualResult.Count(), expectedResult);
        }
    }
}
