﻿namespace ParadiseGuestHouse.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using ParadiseGuestHouse.Common;
    using ParadiseGuestHouse.Data.Common.Repositories;
    using ParadiseGuestHouse.Data.Models;
    using ParadiseGuestHouse.Services.Mapping;
    using ParadiseGuestHouse.Web.InputModels.Restaurant;

    public class RestaurantsService : IRestaurantService
    {
        private readonly IDeletableEntityRepository<Restaurant> restaurantRepository;
        private readonly IDeletableEntityRepository<RestaurantReservation> restaurantReservationRepository;

        public RestaurantsService(
            IDeletableEntityRepository<Restaurant> restaurantRepository,
            IDeletableEntityRepository<RestaurantReservation> restaurantReservationRepository)
        {
            this.restaurantRepository = restaurantRepository;
            this.restaurantReservationRepository = restaurantReservationRepository;
        }

        public async Task<IEnumerable<TViewModel>> GetAllReservationsAsync<TViewModel>(string userId)
        {
            var result = await this.restaurantReservationRepository
              .All()
              .Where(r => r.IsDeleted != true && r.UserId == userId)
              .To<TViewModel>()
              .ToListAsync();

            var datesBeforeToday = await this.restaurantReservationRepository
                .All()
                .Where(x => x.EventDate < DateTime.Now && x.CheckOut < DateTime.Now)
                .ToListAsync();

            var restaurants = await this.restaurantRepository.All().Where(x => x.IsDeleted == false).ToListAsync();

            if (datesBeforeToday != null && datesBeforeToday.Count > 0)
            {
                foreach (var item in datesBeforeToday)
                {
                    this.restaurantReservationRepository.Delete(item);

                    foreach (var rest in restaurants.Where(x => x.CurrentCapacity != x.MaxCapacity))
                    {
                        rest.CurrentCapacity = rest.MaxCapacity;
                    }
                }
            }

            await this.restaurantRepository.SaveChangesAsync();
            await this.restaurantReservationRepository.SaveChangesAsync();

            if (result != null)
            {
                return result;
            }

            throw new InvalidOperationException(GlobalConstants.InvalidOperationExceptionForRestaurantGetAllReservations);
        }

        public async Task<IEnumerable<TViewModel>> GetAllReservationsAsyncForAdmin<TViewModel>()
        {
            var result = await this.restaurantReservationRepository
              .All()
              .Where(r => r.IsDeleted != true)
              .To<TViewModel>()
              .ToListAsync();

            var datesBeforeToday = await this.restaurantReservationRepository
                .All()
                .Where(x => x.EventDate < DateTime.Now && x.CheckOut < DateTime.Now)
                .ToListAsync();

            var restaurants = await this.restaurantRepository.All().Where(x => x.IsDeleted == false).ToListAsync();

            if (datesBeforeToday != null && datesBeforeToday.Count > 0)
            {
                foreach (var item in datesBeforeToday)
                {
                    this.restaurantReservationRepository.Delete(item);

                    foreach (var rest in restaurants.Where(x => x.CurrentCapacity != x.MaxCapacity))
                    {
                        rest.CurrentCapacity = rest.MaxCapacity;
                    }
                }
            }

            await this.restaurantRepository.SaveChangesAsync();
            await this.restaurantReservationRepository.SaveChangesAsync();

            if (result != null)
            {
                return result;
            }

            throw new InvalidOperationException(GlobalConstants.InvalidOperationExceptionForRestaurantGetAllReservationsForAdmin);
        }

        public async Task<bool> ReserveRestaurant(RestaurantInputModel input)
        {
            var restaurant = this.restaurantRepository.All().FirstOrDefault(x => x.IsDeleted == false);

            if (restaurant != null && input.NumberOfGuests <= restaurant.MaxCapacity && input.EventDate.Day >= DateTime.Now.Day)
            {
                var restaurantReservation = new RestaurantReservation()
                {
                    UserId = input.UserId,
                    RestaurantId = restaurant.Id,
                    NumberOfGuests = input.NumberOfGuests,
                    PhoneNumber = input.PhoneNumber,
                    EventType = input.EventType,
                    EventDate = input.EventDate,
                    CheckIn = input.CheckIn,
                    CheckOut = input.CheckOut,
                    TotalPrice = 0,
                    Message = input.Message,
                };

                var totalHours = (decimal)(restaurantReservation.CheckIn - restaurantReservation.CheckOut).TotalHours;

                var price = Math.Abs(restaurant.Price * totalHours);

                restaurantReservation.TotalPrice = price;

                var allReservationsForDate = this.restaurantReservationRepository.All().Where(x => x.EventDate == input.EventDate);

                var allReservations = this.restaurantReservationRepository.All().Select(x => x.EventDate).ToList();

                if (allReservationsForDate.Count() != 0)
                {
                    foreach (var item in allReservationsForDate)
                    {
                        if (restaurantReservation.NumberOfGuests > restaurant.CurrentCapacity)
                        {
                            return false;
                        }
                    }
                }

                if (allReservations.Contains(input.EventDate))
                {
                    restaurant.CurrentCapacity -= input.NumberOfGuests;
                }
                else
                {
                    restaurant.CurrentCapacity = restaurant.MaxCapacity;
                    restaurant.CurrentCapacity -= input.NumberOfGuests;
                }

                await this.restaurantReservationRepository.AddAsync(restaurantReservation);

                await this.restaurantReservationRepository.SaveChangesAsync();

                return true;
            }

            throw new InvalidOperationException(GlobalConstants.InvalidOperationExceptionForRestaurantReservation);
        }

        public int GetRemainingCapacity()
        => this.restaurantRepository.All().First().CurrentCapacity;
    }
}
