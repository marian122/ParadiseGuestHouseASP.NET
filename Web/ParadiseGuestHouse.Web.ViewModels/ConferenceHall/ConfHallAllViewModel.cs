using ParadiseGuestHouse.Data.Models;
using ParadiseGuestHouse.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParadiseGuestHouse.Web.ViewModels.ConferenceHall
{
    public class ConfHallAllViewModel : IMapFrom<ConferenceHallReservation>
    {
        public ApplicationUser User { get; set; }

        public string PhoneNumber { get; set; }

        public string EventType { get; set; }

        public int NumberOfGuests { get; set; }

        public DateTime EventDate { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public decimal TotalPrice { get; set; }

    }
}
