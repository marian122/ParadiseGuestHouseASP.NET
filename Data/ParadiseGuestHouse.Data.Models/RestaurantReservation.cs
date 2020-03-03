namespace ParadiseGuestHouse.Data.Models
{
    using System;

    using ParadiseGuestHouse.Data.Common.Models;
    using ParadiseGuestHouse.Data.Models.Enums;

    public class RestaurantReservation : BaseDeletableModel<string>
    {
        public RestaurantReservation()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public int NumberOfGuests { get; set; }

        public RestaurantEventType EventType { get; set; }

        public DateTime DateOfMeeting { get; set; }

        public DateTime ArrivalTime { get; set; }

        public string Message { get; set; }
    }
}
