namespace ParadiseGuestHouse.Data.Models
{
    using System;

    using ParadiseGuestHouse.Data.Common.Models;
    using ParadiseGuestHouse.Data.Models.Enums;

    public class ConferenceHallReservation : BaseDeletableModel<string>
    {
        public ConferenceHallReservation()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string PhoneNumber { get; set; }

        public int NumberOfGuests { get; set; }

        public decimal TotalPrice { get; set; }

        public ConfHallEventType EventType { get; set; }

        public DateTime DateOfEvent { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public string ConferenceHallId { get; set; }

        public ConferenceHall ConferenceHall { get; set; }

        public string Message { get; set; }
    }
}
