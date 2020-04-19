namespace ParadiseGuestHouse.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ParadiseGuestHouse.Services.Data;
    using ParadiseGuestHouse.Web.ViewModels.ConferenceHall;
    using ParadiseGuestHouse.Web.ViewModels.Restaurant;
    using ParadiseGuestHouse.Web.ViewModels.RoomViewModels;

    public class ReservationsController : Controller
    {
        private readonly IRestaurantService restaurantService;
        private readonly IConferenceHallService conferenceHallService;
        private readonly IRoomsService roomsService;

        public ReservationsController(
            IRestaurantService restaurantService,
            IConferenceHallService conferenceHallService,
            IRoomsService roomsService)
        {
            this.restaurantService = restaurantService;
            this.conferenceHallService = conferenceHallService;
            this.roomsService = roomsService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AllRoomReservations()
        {
            var reservations = await this.roomsService
                .GetAllReservationsAsyncForAdmin<ReservationsAllViewModel>();

            var reservationView = new ReservationViewModel()
            {
                AllReservations = reservations,
            };

            return this.View("~/Views/Room/Reservations.cshtml", reservationView);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AllRestaurantReservations()
        {
            var reservations = await this.restaurantService
                .GetAllReservationsAsyncForAdmin<RestaurantAllViewModel>();

            var reservationView = new RestaurantViewModel()
            {
                AllReservations = reservations,
            };

            return this.View("~/Views/Restaurant/Reservations.cshtml", reservationView);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AllConferenceHallReservations()
        {
            var reservations = await this.conferenceHallService
                 .GetAllReservationsAsyncForAdmin<ConfHallAllViewModel>();

            var reservationView = new ConfHallViewModel()
            {
                AllReservations = reservations,
            };

            return this.View("~/Views/ConferenceHall/Reservations.cshtml", reservationView);
        }
    }
}
