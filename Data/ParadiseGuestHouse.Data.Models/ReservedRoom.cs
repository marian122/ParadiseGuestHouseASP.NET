namespace ParadiseGuestHouse.Data.Models
{
    using System;

    using ParadiseGuestHouse.Data.Common.Models;

    public class ReservedRoom : BaseDeletableModel<string>
    {
        public string RoomId { get; set; }

        public Room Room { get; set; }

        public string ReservationId { get; set; }

        public Reservation Reservation { get; set; }
    }
}
