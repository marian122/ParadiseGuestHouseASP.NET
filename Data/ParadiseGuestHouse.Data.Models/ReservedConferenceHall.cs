namespace ParadiseGuestHouse.Data.Models
{
    using ParadiseGuestHouse.Data.Common.Models;

    public class ReservedConferenceHall
    {
        public string ConferenceHallId { get; set; }

        public ConferenceHall ConferenceHall { get; set; }

        public string ConferenceHallReservationId { get; set; }

        public ConferenceHallReservation ConferenceHallReservation { get; set; }
    }
}