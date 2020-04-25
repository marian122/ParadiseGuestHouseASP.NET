using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using ParadiseGuestHouse.Data;
using ParadiseGuestHouse.Data.Models;
using ParadiseGuestHouse.Data.Models.Enums;
using ParadiseGuestHouse.Data.Repositories;
using ParadiseGuestHouse.Services.Data;
using ParadiseGuestHouse.Services.Mapping;
using ParadiseGuestHouse.Tests.Common;
using ParadiseGuestHouse.Web.InputModels.Room;
using ParadiseGuestHouse.Web.ViewModels.RoomViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ParadiseGuestHouse.Services.Tests
{
    [Collection(nameof(MapperFixture))]
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

        [Fact]
        public async Task AdministratorCreateRoom_WithValidData_ShouldReturnRoom()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(Guid.NewGuid().ToString())
                          .Options;

            this.dbContext = new ApplicationDbContext(options);

            var roomRepository = new EfDeletableEntityRepository<Room>(this.dbContext);
            var roomReservationRepository = new EfDeletableEntityRepository<RoomReservation>(this.dbContext);
            var pictureRepository = new EfDeletableEntityRepository<Picture>(this.dbContext);
            var pictureService = new PictureService(pictureRepository);
            var moqCloudinaryService = new Mock<ICloudinaryService>();
            var moqIFormFile = new Mock<IFormFile>();

            this.roomService = new RoomsService(roomRepository, roomReservationRepository, pictureService, moqCloudinaryService.Object);

            var room = new CreateRoomInputModel
            {
                RoomType = (RoomType)Enum.Parse(typeof(RoomType), "SingleRoom"),
                Price = 10,
                Pictures = new List<IFormFile>
                {
                    moqIFormFile.Object
                },
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

            var actual = await this.roomService.CreateRoomAsync(room);

            Assert.True(actual);
        }

        [Fact]
        public async Task DeleteRoom_ShouldDelete()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(Guid.NewGuid().ToString())
                          .Options;

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

            await this.dbContext.AddAsync(room);
            await this.dbContext.SaveChangesAsync();

            var deletingRoom = this.dbContext.Rooms.FirstOrDefault(x => x.Id == room.Id);

            var actual = await this.roomService.DeleteRoom(deletingRoom.Id);

            Assert.True(actual);
        }

        [Fact]
        public async Task Get_All_Rooms_Should_Return_All_Rooms()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(Guid.NewGuid().ToString())
                          .Options;

            this.dbContext = new ApplicationDbContext(options);

            var roomRepository = new EfDeletableEntityRepository<Room>(this.dbContext);
            var roomReservationRepository = new EfDeletableEntityRepository<RoomReservation>(this.dbContext);
            var pictureRepository = new EfDeletableEntityRepository<Picture>(this.dbContext);
            var pictureService = new PictureService(pictureRepository);
            var moqCloudinaryService = new Mock<ICloudinaryService>();

            await roomRepository.AddAsync(new Room
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
                NumberOfBeds = 3,
            });

            await roomRepository.SaveChangesAsync();

            this.roomService = new RoomsService(roomRepository, roomReservationRepository, pictureService, moqCloudinaryService.Object);


            var actualResult = await this.roomService
                .GetAllRoomsAsync<RoomsAllViewModel>();

            int expectedResult = 1;
            Assert.Equal(actualResult.Count(), expectedResult);
        }

        [Fact]
        public async Task Get_All_Rooms_Should_Return_Zero()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(Guid.NewGuid().ToString())
                          .Options;

            this.dbContext = new ApplicationDbContext(options);

            var roomRepository = new EfDeletableEntityRepository<Room>(this.dbContext);
            var roomReservationRepository = new EfDeletableEntityRepository<RoomReservation>(this.dbContext);
            var pictureRepository = new EfDeletableEntityRepository<Picture>(this.dbContext);
            var pictureService = new PictureService(pictureRepository);
            var moqCloudinaryService = new Mock<ICloudinaryService>();


            this.roomService = new RoomsService(roomRepository, roomReservationRepository, pictureService, moqCloudinaryService.Object);

            var actualResult = await this.roomService
                .GetAllRoomsAsync<RoomsAllViewModel>();

            int expectedResult = 0;
            Assert.Equal(actualResult.Count(), expectedResult);
        }

        [Fact]
        public async Task Get_Room_By_Id_Should_Return_Correct_Room()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(Guid.NewGuid().ToString())
                          .Options;

            this.dbContext = new ApplicationDbContext(options);

            var roomRepository = new EfDeletableEntityRepository<Room>(this.dbContext);
            var roomReservationRepository = new EfDeletableEntityRepository<RoomReservation>(this.dbContext);
            var pictureRepository = new EfDeletableEntityRepository<Picture>(this.dbContext);
            var pictureService = new PictureService(pictureRepository);
            var moqCloudinaryService = new Mock<ICloudinaryService>();

            await roomRepository.AddAsync(new Room
            {
                Id = "1",
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
                NumberOfBeds = 3,
            });

            await roomRepository.SaveChangesAsync();

            this.roomService = new RoomsService(roomRepository, roomReservationRepository, pictureService, moqCloudinaryService.Object);

            var actualResult = await this.roomService
                .GetRoomAsync<RoomsAllViewModel>("1");

            string expectedResult = "1";
            Assert.Equal(actualResult.Id, expectedResult);
        }

        [Fact]
        public async Task Reserve_Room_Should_Make_One_Reservation()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(Guid.NewGuid().ToString())
                          .Options;

            this.dbContext = new ApplicationDbContext(options);

            var roomRepository = new EfDeletableEntityRepository<Room>(this.dbContext);
            var roomReservationRepository = new EfDeletableEntityRepository<RoomReservation>(this.dbContext);
            var pictureRepository = new EfDeletableEntityRepository<Picture>(this.dbContext);
            var pictureService = new PictureService(pictureRepository);
            var moqCloudinaryService = new Mock<ICloudinaryService>();

            await roomRepository.AddAsync(new Room
            {
                Id = "1",
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
                NumberOfBeds = 3,
            });

            await roomRepository.SaveChangesAsync();

            this.roomService = new RoomsService(roomRepository, roomReservationRepository, pictureService, moqCloudinaryService.Object);


            var reservation = new ReserveRoomInputModel
            {
                CheckIn = DateTime.Now.AddDays(1),
                CheckOut = DateTime.Now.AddDays(3),
                CountOfPeople = 2,
                RoomId = "1",
                Email = "maleksiev12@gmail.com",
                FirstName = "Marian",
                LastName = "Kyuchukov",
                PhoneNumber = "0888186978",
            };

            var actualResult = await this.roomService.ReserveRoom(reservation);

            Assert.True(actualResult);
        }

        [Fact]
        public async Task Get_All_Reservations_Should_Return_All_Reservations()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                          .UseInMemoryDatabase(Guid.NewGuid().ToString())
                          .Options;

            this.dbContext = new ApplicationDbContext(options);

            var roomRepository = new EfDeletableEntityRepository<Room>(this.dbContext);
            var roomReservationRepository = new EfDeletableEntityRepository<RoomReservation>(this.dbContext);
            var pictureRepository = new EfDeletableEntityRepository<Picture>(this.dbContext);
            var pictureService = new PictureService(pictureRepository);
            var moqCloudinaryService = new Mock<ICloudinaryService>();

            await roomRepository.AddAsync(new Room
            {
                Id = "1",
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
                NumberOfBeds = 3,
            });

            await roomRepository.SaveChangesAsync();

            await roomReservationRepository.AddAsync(new RoomReservation
            {
                Id = "1",
                RoomType = (RoomType)Enum.Parse(typeof(RoomType), "SingleRoom"),
                CheckIn = DateTime.Now.AddDays(1),
                CheckOut = DateTime.Now.AddDays(3),
                NumberOfGuests = 2,
                RoomId = "1",
                UserId = "1",

            });

            await roomReservationRepository.SaveChangesAsync();

            this.roomService = new RoomsService(roomRepository, roomReservationRepository, pictureService, moqCloudinaryService.Object);

            int expectedResult = 1;

            var actualResult = await this.roomService.GetAllReservationsAsync<ReservationsAllViewModel>("1");

            Assert.Equal(actualResult.Count(), expectedResult);
        }

    }
}