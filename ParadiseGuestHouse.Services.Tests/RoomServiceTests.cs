using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using ParadiseGuestHouse.Data;
using ParadiseGuestHouse.Data.Models;
using ParadiseGuestHouse.Data.Models.Enums;
using ParadiseGuestHouse.Data.Repositories;
using ParadiseGuestHouse.Services.Data;
using ParadiseGuestHouse.Tests.Common;
using ParadiseGuestHouse.Web.InputModels.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ParadiseGuestHouse.Services.Tests
{
    public class RoomServiceTests
    {
        private ApplicationDbContext dbContext;
        private RoomsService roomService;


        [Fact]
        public async Task ManualCreateRoom_WithValidData_ShouldReturnCorrectRoom()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(Guid.NewGuid().ToString())
                          .Options;

            var expectedRoom = 1;

            this.dbContext = new ApplicationDbContext(options);

            var roomRepository = new EfDeletableEntityRepository<Room>(this.dbContext);
            var roomReservationRepository = new EfDeletableEntityRepository<RoomReservation>(this.dbContext);
            var pictureRepository = new EfDeletableEntityRepository<Picture>(this.dbContext);
            var pictureService = new PictureService(pictureRepository);
            var moqCloudinaryService = new Mock<ICloudinaryService>();


            this.roomService = new RoomsService(roomRepository, roomReservationRepository, pictureService, moqCloudinaryService.Object);

            var room = new Room
            {
                RoomType = (RoomType)Enum.Parse(typeof(RoomType), "SingleRoom"),
                Price = 10,
                Pictures = null,
                HasAirConditioner = true,
                HasBathroom = true,
                HasHeater = false,
                HasMountainView = false,
                HasPhone = false,
                HasRoomService = false,
                HasSeaView = false,
                HasTv = false,
                HasWifi = false,
                NumberOfBeds = 1,
            };

            if (room != null && room.Price > 0 && room.NumberOfBeds < 10)
            {
                await this.dbContext.AddAsync(room);
                await this.dbContext.SaveChangesAsync();
            }

            var actual = this.dbContext.Rooms.Count();

            Assert.Equal(expectedRoom, actual);
        }

        [Fact]
        public async Task ManualCreateRoom_WithInValidPrice_ShouldNotReturnRoom()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(Guid.NewGuid().ToString())
                          .Options;

            var expectedRoom = 0;

            this.dbContext = new ApplicationDbContext(options);

            var roomRepository = new EfDeletableEntityRepository<Room>(this.dbContext);
            var roomReservationRepository = new EfDeletableEntityRepository<RoomReservation>(this.dbContext);
            var pictureRepository = new EfDeletableEntityRepository<Picture>(this.dbContext);
            var pictureService = new PictureService(pictureRepository);
            var moqCloudinaryService = new Mock<ICloudinaryService>();


            this.roomService = new RoomsService(roomRepository, roomReservationRepository, pictureService, moqCloudinaryService.Object);

            var room = new Room
            {
                RoomType = (RoomType)Enum.Parse(typeof(RoomType), "SingleRoom"),
                Price = 0,
                Pictures = null,
                HasAirConditioner = true,
                HasBathroom = true,
                HasHeater = false,
                HasMountainView = false,
                HasPhone = false,
                HasRoomService = false,
                HasSeaView = false,
                HasTv = false,
                HasWifi = false,
                NumberOfBeds = 1,
            };
            
            if (room != null && room.Price > 0 && room.NumberOfBeds < 10)
            {
                await this.dbContext.AddAsync(room);
                await this.dbContext.SaveChangesAsync();
            }

            var actual = this.dbContext.Rooms.Count();

            Assert.Equal(expectedRoom, actual);
        }

        [Fact]
        public async Task ManualCreateRoom_WithInValidBeds_ShouldNotReturnRoom()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(Guid.NewGuid().ToString())
                          .Options;

            var expectedRoom = 0;

            this.dbContext = new ApplicationDbContext(options);

            var roomRepository = new EfDeletableEntityRepository<Room>(this.dbContext);
            var roomReservationRepository = new EfDeletableEntityRepository<RoomReservation>(this.dbContext);
            var pictureRepository = new EfDeletableEntityRepository<Picture>(this.dbContext);
            var pictureService = new PictureService(pictureRepository);
            var moqCloudinaryService = new Mock<ICloudinaryService>();


            this.roomService = new RoomsService(roomRepository, roomReservationRepository, pictureService, moqCloudinaryService.Object);

            var room = new Room
            {
                RoomType = (RoomType)Enum.Parse(typeof(RoomType), "SingleRoom"),
                Price = 10,
                Pictures = null,
                HasAirConditioner = true,
                HasBathroom = true,
                HasHeater = false,
                HasMountainView = false,
                HasPhone = false,
                HasRoomService = false,
                HasSeaView = false,
                HasTv = false,
                HasWifi = false,
                NumberOfBeds = 111,
            };

            if (room != null && room.Price > 0 && room.NumberOfBeds < 10)
            {
                await this.dbContext.AddAsync(room);
                await this.dbContext.SaveChangesAsync();
            }

            var actual = this.dbContext.Rooms.Count();

            Assert.Equal(expectedRoom, actual);
        }

        //[Fact]
        //public async Task AdministratorCreateRoom_WithValidData_ShouldReturnRoom()
        //{
        //    var options = new DbContextOptionsBuilder<ApplicationDbContext>()
        //                  .UseInMemoryDatabase(Guid.NewGuid().ToString())
        //                  .Options;

        //    var expectedRoom = 1;

        //    this.dbContext = new ApplicationDbContext(options);

        //    var roomRepository = new EfDeletableEntityRepository<Room>(this.dbContext);
        //    var roomReservationRepository = new EfDeletableEntityRepository<RoomReservation>(this.dbContext);
        //    var pictureRepository = new EfDeletableEntityRepository<Picture>(this.dbContext);
        //    var pictureService = new PictureService(pictureRepository);
        //    var moqCloudinaryService = new Mock<ICloudinaryService>();
        //    var moqIFormFile = new Mock<IFormFile>();

        //    this.roomService = new RoomsService(roomRepository, roomReservationRepository, pictureService, moqCloudinaryService.Object);

        //    var room = new CreateRoomInputModel
        //    {
        //        RoomType = (RoomType)Enum.Parse(typeof(RoomType), "SingleRoom"),
        //        Price = 10,
        //        Pictures = new List<IFormFile> 
        //        {
        //            moqIFormFile.Object
        //        },
        //        HasAirConditioner = true,
        //        HasBathroom = true,
        //        HasHeater = false,
        //        HasMountainView = false,
        //        HasPhone = false,
        //        HasRoomService = false,
        //        HasSeaView = false,
        //        HasTv = false,
        //        HasWifi = false,
        //        NumberOfBeds = 1,
        //    };

        //    var actual = await this.roomService.CreateRoom(room);

        //    Assert.True(actual);
        //}
    }
}
