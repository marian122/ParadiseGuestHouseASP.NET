namespace ParadiseGuestHouse.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using ParadiseGuestHouse.Data.Common.Models;

    public class RestaurantReservation : BaseDeletableModel<string>
    {
        public RestaurantReservation()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public int NumberOfGuests { get; set; }

        public DateTime DateOfMeeting { get; set; }

        public DateTime ArrivalTime { get; set; }

        public string Message { get; set; }
    }
}
