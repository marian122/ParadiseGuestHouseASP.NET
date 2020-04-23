namespace ParadiseGuestHouse.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
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

            var eventDate = await this.restaurantReservationRepository
                .All()
                .Where(x => x.EventDate < DateTime.Now && x.CheckOut < DateTime.Now)
                .ToListAsync();

            var conferenceHalls = await this.restaurantRepository.All().Where(x => x.IsDeleted == false).ToListAsync();

            if (eventDate != null && eventDate.Count > 0)
            {
                foreach (var item in eventDate)
                {
                    this.restaurantReservationRepository.Delete(item);

                    foreach (var hall in conferenceHalls.Where(x => x.CurrentCapacity != x.MaxCapacity))
                    {
                        hall.CurrentCapacity = hall.MaxCapacity;
                    }
                }
            }

            await this.restaurantRepository.SaveChangesAsync();
            await this.restaurantReservationRepository.SaveChangesAsync();

            return result;
        }

        public async Task<IEnumerable<TViewModel>> GetAllReservationsAsyncForAdmin<TViewModel>()
        {
            var result = await this.restaurantReservationRepository
              .All()
              .Where(r => r.IsDeleted != true)
              .To<TViewModel>()
              .ToListAsync();

            var eventDate = await this.restaurantReservationRepository
                .All()
                .Where(x => x.EventDate < DateTime.Now && x.CheckOut < DateTime.Now)
                .ToListAsync();

            var conferenceHalls = await this.restaurantRepository.All().Where(x => x.IsDeleted == false).ToListAsync();

            if (eventDate != null && eventDate.Count > 0)
            {
                foreach (var item in eventDate)
                {
                    this.restaurantReservationRepository.Delete(item);

                    foreach (var hall in conferenceHalls.Where(x => x.CurrentCapacity != x.MaxCapacity))
                    {
                        hall.CurrentCapacity = hall.MaxCapacity;
                    }
                }
            }

            await this.restaurantRepository.SaveChangesAsync();
            await this.restaurantReservationRepository.SaveChangesAsync();

            return result;
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

                restaurant.CurrentCapacity = restaurant.MaxCapacity;

                restaurant.CurrentCapacity -= restaurantReservation.NumberOfGuests;

                await this.restaurantReservationRepository.AddAsync(restaurantReservation);

                var result = await this.restaurantReservationRepository.SaveChangesAsync();

                return result > 0;
            }

            throw new NullReferenceException();
        }

        public async Task<bool> FillOccupiedDates(RestaurantInputModel input)
        {
            var restaurant = this.restaurantRepository.All().First();

            restaurant.OccupiedDates.Add(input.EventDate.ToString());

            var result = await this.restaurantRepository.SaveChangesAsync();

            return result > 0;
        }

        public int GetRemainingCapacity()
        => this.restaurantRepository.All().First().CurrentCapacity;
    }
}
