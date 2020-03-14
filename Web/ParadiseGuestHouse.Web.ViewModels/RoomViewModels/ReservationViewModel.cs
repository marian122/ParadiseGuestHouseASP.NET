namespace ParadiseGuestHouse.Web.ViewModels.RoomViewModels
{
    using ParadiseGuestHouse.Data.Models;
    using ParadiseGuestHouse.Services.Mapping;
    using System.Collections;
    using System.Collections.Generic;

    public class ReservationViewModel
    {
        public IEnumerable<ReservationsAllViewModel> AllReservations { get; set; }
    }
}
