namespace ParadiseGuestHouse.Data.Models
{
    using ParadiseGuestHouse.Data.Common.Models;
    using System;

    public class ReservedRoom : BaseDeletableModel<string>
    {
        public ReservedRoom()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public int RoomId { get; set; }

        public Room Room { get; set; }

        public int ReservationId { get; set; }

        public Reservation Reservation { get; set; }
    }
}
