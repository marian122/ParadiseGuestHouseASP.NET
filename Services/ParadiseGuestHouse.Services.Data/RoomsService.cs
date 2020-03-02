namespace ParadiseGuestHouse.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
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
    }
}
