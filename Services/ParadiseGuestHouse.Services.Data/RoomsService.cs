namespace ParadiseGuestHouse.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using ParadiseGuestHouse.Data.Common.Repositories;
    using ParadiseGuestHouse.Data.Models;
    using ParadiseGuestHouse.Data.Models.Enums;
    using ParadiseGuestHouse.Services.Mapping;
    using ParadiseGuestHouse.Web.InputModels.Room;

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

        public async Task<IEnumerable<TViewModel>> GetAllReservationsAsync<TViewModel>(string userId)
        {
            var reservations = await this.roomReservationRepository
            .All()
            .Where(r => r.IsDeleted != true
            && r.UserId == userId
            && r.CheckIn > DateTime.Now // UtcNow
            && r.CheckOut > DateTime.Now) // UtcNow
            .To<TViewModel>()
            .ToListAsync();

            var reservationCheckOut = await this.roomReservationRepository.All().Where(x => x.CheckOut < DateTime.Now).ToListAsync();

            if (reservationCheckOut.Any())
            {
                foreach (var res in reservationCheckOut)
                {
                    this.roomReservationRepository.Delete(res);

                    await this.roomReservationRepository.SaveChangesAsync();
                }
            }

            return reservations;
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
                    PhoneNumber = input.PhoneNumber,
                    CheckIn = input.CheckIn,
                    CheckOut = input.CheckOut,
                    TotalPrice = 0,
                    NumberOfGuests = input.CountOfPeople,
                    NumberOfNights = 0,
                };

                var days = (reservation.CheckOut - reservation.CheckIn).TotalDays;

                var totalPrice = ((decimal)days * room.Price) * reservation.NumberOfGuests;

                reservation.NumberOfNights = (int)days;

                reservation.TotalPrice = totalPrice;

                await this.roomReservationRepository.AddAsync(reservation);

                int result = await this.roomReservationRepository.SaveChangesAsync();
                return result > 0;
            }

            throw new NullReferenceException();
        }
    }
}
