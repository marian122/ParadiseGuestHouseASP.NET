namespace ParadiseGuestHouse.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using ParadiseGuestHouse.Data.Common.Models;

    public class Guest : BaseDeletableModel<string>
    {
        public Guest()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int PhoneNumber { get; set; }

        public string Email { get; set; }

        public string RoomReservationId { get; set; }

        public RoomReservation RoomReservation { get; set; }

        public string ConferenceHallReservationId { get; set; }

        public ConferenceHallReservation ConferenceHallReservation { get; set; }
    }
}
