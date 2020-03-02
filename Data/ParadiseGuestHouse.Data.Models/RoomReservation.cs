namespace ParadiseGuestHouse.Data.Models
{
    using System;
    using System.Collections.Generic;

    using ParadiseGuestHouse.Data.Common.Models;
    using ParadiseGuestHouse.Data.Models.Enums;

    public class RoomReservation : BaseDeletableModel<string>
    {
        public RoomReservation()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public RoomType RoomType { get; set; }

        public int NumberOfGuests { get; set; }

        public int NumberOfNights { get; set; }
    }
}
