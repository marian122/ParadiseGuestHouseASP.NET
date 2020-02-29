namespace ParadiseGuestHouse.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using ParadiseGuestHouse.Data.Common.Repositories;
    using ParadiseGuestHouse.Data.Models;
    using ParadiseGuestHouse.Data.Models.Enums;
    using ParadiseGuestHouse.Services.Mapping;

    public class RoomsService : IRoomsService
    {
        private readonly IDeletableEntityRepository<Room> repository;

        public RoomsService(IDeletableEntityRepository<Room> repository)
        {
            this.repository = repository;
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
    }
}
