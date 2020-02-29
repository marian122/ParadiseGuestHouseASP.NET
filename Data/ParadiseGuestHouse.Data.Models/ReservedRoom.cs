namespace ParadiseGuestHouse.Data.Models
{
    using System;

    using ParadiseGuestHouse.Data.Common.Models;

    public class ReservedRoom
    {
        public string RoomId { get; set; }

        public Room Room { get; set; }

        public string RoomReservationId { get; set; }

        public RoomReservation RoomReservation { get; set; }
    }
}
