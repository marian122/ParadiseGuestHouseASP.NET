using Microsoft.EntityFrameworkCore;
using ParadiseGuestHouse.Data.Common.Repositories;
using ParadiseGuestHouse.Data.Models;
using ParadiseGuestHouse.Services.Mapping;
using ParadiseGuestHouse.Web.InputModels.ConferenceHall;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParadiseGuestHouse.Services.Data
{
    public class ConferenceHallService : IConferenceHallService
    {
        private readonly IDeletableEntityRepository<ConferenceHallReservation> conferenceHallReservationRepository;
        private readonly IDeletableEntityRepository<ConferenceHall> conferenceHallRepository;

        public ConferenceHallService(
            IDeletableEntityRepository<ConferenceHallReservation> conferenceHallReservationRepository,
            IDeletableEntityRepository<ConferenceHall> conferenceHallRepository)
        {
            this.conferenceHallReservationRepository = conferenceHallReservationRepository;
            this.conferenceHallRepository = conferenceHallRepository;
        }

        public async Task<IEnumerable<TViewModel>> GetAllReservationsAsync<TViewModel>(string userId)
        {
            var result = await this.conferenceHallReservationRepository
              .All()
              .Where(r => r.IsDeleted != true && r.UserId == userId)
              .To<TViewModel>()
              .ToListAsync();

            var eventDate = await this.conferenceHallReservationRepository
                .All()
                .Where(x => x.DateOfEvent < DateTime.Now && x.CheckOut < DateTime.Now)
                .ToListAsync();

            if (eventDate != null && eventDate.Count > 0)
            {
                foreach (var item in eventDate)
                {
                    this.conferenceHallReservationRepository.Delete(item);
                }
            }

            await this.conferenceHallRepository.SaveChangesAsync();
            await this.conferenceHallReservationRepository.SaveChangesAsync();

            return result;
        }

        public async Task<bool> ReserveConferenceHall(ConferenceHallInputModel input)
        {
            var conferenceHall = this.conferenceHallRepository.All()
                .FirstOrDefault(c => c.IsDeleted == false && c.Capacity > 0 && c.ConfHallType == input.EventType);

            var conferenceHallReservation = new ConferenceHallReservation()
            {
                UserId = input.UserId,
                PhoneNumber = input.PhoneNumber,
                NumberOfGuests = input.NumberOfGuests,
                TotalPrice = 0,
                EventType = input.EventType,
                DateOfEvent = input.EventDate,
                CheckIn = input.CheckIn,
                CheckOut = input.CheckOut,
            };

            var totalHours = (decimal)(conferenceHallReservation.CheckIn - conferenceHallReservation.CheckOut).TotalHours;

            var price = Math.Abs(conferenceHall.Price * totalHours);

            conferenceHallReservation.TotalPrice = price;

            conferenceHall.Capacity -= conferenceHallReservation.NumberOfGuests;

            await this.conferenceHallReservationRepository.AddAsync(conferenceHallReservation);

            var result = await this.conferenceHallReservationRepository.SaveChangesAsync();

            return result > 0;
        }
    }
}
