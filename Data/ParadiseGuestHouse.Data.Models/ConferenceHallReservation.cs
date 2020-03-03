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

        public int NumberOfGuests { get; set; }

        public ConfHallEventType EventType { get; set; }

        public DateTime DateOfEvent { get; set; }

        public DateTime ArrivalTime { get; set; }

        public DateTime LeaveTime { get; set; }

        public string Message { get; set; }
    }
}
