﻿namespace ParadiseGuestHouse.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using ParadiseGuestHouse.Data.Common.Repositories;
    using ParadiseGuestHouse.Data.Models;
    using ParadiseGuestHouse.Services.Mapping;
    using ParadiseGuestHouse.Web.InputModels.Room;
    using ParadiseGuestHouse.Web.ViewModels.Room;

    public class RoomsService : IRoomsService
    {
        private readonly IDeletableEntityRepository<Room> repository;
        private readonly IDeletableEntityRepository<RoomReservation> roomReservationRepository;
        private readonly IPictureService pictureService;
        private readonly ICloudinaryService cloudinaryService;

        public RoomsService(
            IDeletableEntityRepository<Room> repository,
            IDeletableEntityRepository<RoomReservation> roomReservationRepository,
            IPictureService pictureService,
            ICloudinaryService cloudinaryService)
        {
            this.repository = repository;
            this.roomReservationRepository = roomReservationRepository;
            this.pictureService = pictureService;
            this.cloudinaryService = cloudinaryService;
        }

        public async Task<bool> CreateRoom(CreateRoomInputModel input)
        {
            string folderName = "room_images";

            var pictureUrls = input.Pictures
                .Select(async x =>
                    await this.cloudinaryService.UploadPhotoAsync(x, x.FileName, folderName))
                .Select(x => x.Result)
                .ToList();

            var room = new Room
            {
                RoomType = input.RoomType,
                Price = input.Price,
                NumberOfBeds = input.NumberOfBeds,
                HasBathroom = input.HasBathroom,
                HasRoomService = input.HasRoomService,
                HasSeaView = input.HasSeaView,
                HasMountainView = input.HasMountainView,
                HasWifi = input.HasWifi,
                HasTv = input.HasTv,
                HasPhone = input.HasPhone,
                HasAirConditioner = input.HasAirConditioner,
                HasHeater = input.HasHeater,
                Pictures = pictureUrls.Select(x => new Picture { Url = x })
                .ToList(),
            };

            if (room != null && room.Price > 0)
            {
                await this.repository.AddAsync(room);
                var result = await this.repository.SaveChangesAsync();

                return result > 0;
            }

            return false;
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

        public async Task<bool> EditRoomAsync(string id, EditRoomViewModel input)
        {
            var currentRoom = this.GetRoomById(id);

            //string folderName = "room_images";

            //var pictureUrls = input.Pictures
            //    .Select(async x =>
            //        await this.cloudinaryService.UploadPhotoAsync(x, x.FileName, folderName))
            //    .Select(x => x.Result)
            //    .ToList();

            currentRoom.RoomType = input.RoomType;
            currentRoom.Price = input.Price;
            currentRoom.NumberOfBeds = input.NumberOfBeds;
            currentRoom.HasWifi = input.HasWifi;
            currentRoom.HasAirConditioner = input.HasAirConditioner;
            currentRoom.HasBathroom = input.HasBathroom;
            currentRoom.HasHeater = input.HasHeater;
            currentRoom.HasMountainView = input.HasMountainView;
            currentRoom.HasPhone = input.HasPhone;
            currentRoom.HasRoomService = input.HasRoomService;
            currentRoom.HasSeaView = input.HasSeaView;
            currentRoom.HasTv = input.HasTv;
            //currentRoom.Pictures = pictureUrls.Select(x => new Picture { Url = x }).ToList();

            this.repository.Update(currentRoom);

            var result = await this.repository.SaveChangesAsync();

            return result > 0;
        }

        public async Task<IEnumerable<TViewModel>> GetAllReservationsAsync<TViewModel>(string userId)
        {
            var reservations = await this.roomReservationRepository
            .All()
            .Where(r => r.IsDeleted == false
            && r.UserId == userId
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

        public async Task<IEnumerable<TViewModel>> GetAllReservationsAsyncForAdmin<TViewModel>()
        {
            var reservations = await this.roomReservationRepository
            .All()
            .Where(r => r.IsDeleted == false && r.CheckOut > DateTime.Now) // UtcNow
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

        public async Task<EditRoomViewModel> GetRoomForEditAsync(string id)
        {
            var room = this.GetRoomById(id);

            var result = new EditRoomViewModel()
            {
                RoomType = room.RoomType,
                Price = room.Price,
                NumberOfBeds = room.NumberOfBeds,
                HasWifi = room.HasWifi,
                HasAirConditioner = room.HasAirConditioner,
                HasBathroom = room.HasBathroom,
                HasHeater = room.HasHeater,
                HasMountainView = room.HasMountainView,
                HasPhone = room.HasPhone,
                HasRoomService = room.HasRoomService,
                HasSeaView = room.HasSeaView,
                HasTv = room.HasTv,
            };

            return result;
        }

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

        private Room GetRoomById(string id)
            => this.repository.All()?.FirstOrDefault(x => x.Id == id);
    }
}