namespace ParadiseGuestHouse.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Security.Principal;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using ParadiseGuestHouse.Data.Common.Repositories;
    using ParadiseGuestHouse.Data.Models;
    using ParadiseGuestHouse.Data.Models.Enums;
    using ParadiseGuestHouse.Services.Mapping;
    using ParadiseGuestHouse.Web.ViewModels.InputModels.Room;

    public class RoomsService : IRoomsService
    {
        private readonly IDeletableEntityRepository<Room> repository;
        private readonly IDeletableEntityRepository<RoomReservation> roomReservationRepository;
        private readonly IUsersService usersService;

        public RoomsService(IDeletableEntityRepository<Room> repository, IDeletableEntityRepository<RoomReservation> roomReservationRepository, IUsersService usersService)
        {
            this.repository = repository;
            this.roomReservationRepository = roomReservationRepository;
            this.usersService = usersService;
        }

        public async Task<bool> CreateRoom(RoomType roomType, decimal price, int numberOfBeds, bool hasBathroom, bool hasRoomService, bool hasSeaView, bool hasMountainView, bool hasWifi, bool hasTv, bool hasPhone, bool hasAirConditioner, bool hasHeater)
        {
            var room = new Room
            {
                RoomType = roomType,
                Price = price,
                NumberOfBeds = numberOfBeds,
                HasBathroom = hasBathroom,
                HasRoomService = hasRoomService,
                HasSeaView = hasSeaView,
                HasMountainView = hasMountainView,
                HasWifi = hasWifi,
                HasTv = hasTv,
                HasPhone = hasPhone,
                HasAirConditioner = hasAirConditioner,
                HasHeater = hasHeater,
            };

            await this.repository.AddAsync(room);
            var result = await this.repository.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> DeleteRoom(string id)
        {
            var room = this.repository
                .All()
                .FirstOrDefault(r => r.Id == id);

            if (room != null)
            {
                this.repository
                    .Delete(room);

                int result = await this.repository.SaveChangesAsync();
                return result > 0;
            }

            throw new NullReferenceException();
        }

        public async Task<IEnumerable<TViewModel>> GetAllRoomsAsync<TViewModel>()
            => await this.repository
            .All()
            .Where(r => r.IsDeleted != true)
            .OrderBy(p => p.Price)
            .To<TViewModel>()
            .ToListAsync();

        public async Task<TViewModel> GetRoomAsync<TViewModel>(string id)
            => await this.repository
            .All()
            .Where(r => r.Id == id && r.IsDeleted != true)
            .To<TViewModel>()
            .FirstOrDefaultAsync();

        public async Task<bool> ReserveRoom(ReserveRoomInputModel input)
        {
            var room = this.repository.All()
                .FirstOrDefault(r => r.Id == input.RoomId);

            if (room != null)
            {
                var reservation = new RoomReservation()
                {
                    UserId = input.UserId,
                    RoomId = room.Id,
                    RoomType = room.RoomType,
                    CheckIn = input.CheckIn,
                    CheckOut = input.CheckOut,
                    TotalPrice = room.Price,
                    NumberOfGuests = input.CountOfPeople,
                    NumberOfNights = 2,
                };

                await this.roomReservationRepository.AddAsync(reservation);

                int result = await this.roomReservationRepository.SaveChangesAsync();
                return result > 0;
            }

            throw new NullReferenceException();
        }
    }
}
