﻿namespace ParadiseGuestHouse.Data.Models
{
    using System;
    using System.Collections.Generic;

    using ParadiseGuestHouse.Data.Common.Models;
    using ParadiseGuestHouse.Data.Models.Enums;

    public class Reservation : BaseDeletableModel<string>
    {
        public Reservation()
        {
            this.Id = Guid.NewGuid().ToString();
            this.ReservedRoom = new HashSet<ReservedRoom>();
        }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public RoomType RoomType { get; set; }

        public int NumberOfGuests { get; set; }

        public int NumberOfNights { get; set; }

        public ICollection<ReservedRoom> ReservedRoom { get; set; }
    }
}
