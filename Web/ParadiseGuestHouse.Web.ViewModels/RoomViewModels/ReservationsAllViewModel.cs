using ParadiseGuestHouse.Data.Models;
using ParadiseGuestHouse.Services.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ParadiseGuestHouse.Web.ViewModels.RoomViewModels
{
    public class ReservationsAllViewModel : IMapFrom<RoomReservation>
    {
        public ApplicationUser User { get; set; }

        public string RoomType { get; set; }

        public int NumberOfGuests { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
