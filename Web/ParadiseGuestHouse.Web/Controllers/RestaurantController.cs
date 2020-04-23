namespace ParadiseGuestHouse.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ParadiseGuestHouse.Services.Data;
    using ParadiseGuestHouse.Web.InputModels.Restaurant;
    using ParadiseGuestHouse.Web.ViewModels.Restaurant;

    public class RestaurantController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IRestaurantService restaurantService;

        public RestaurantController(IUsersService usersService, IRestaurantService restaurantService)
        {
            this.usersService = usersService;
            this.restaurantService = restaurantService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Reserve()
        {
            var inputModel = new RestaurantInputModel
            {
                PhoneNumber = await this.usersService.GetUserPhoneNumberAsync(this.User),
                EventDate = DateTime.Now,
            };

            return this.View(inputModel);
        }

        [HttpPost]
        public async Task<IActionResult> Reserve(RestaurantInputModel input)
        {
            var remainingCapacity = this.restaurantService.GetRemainingCapacity();
            if (!this.ModelState.IsValid || remainingCapacity < input.NumberOfGuests)
            {
                this.ModelState.AddModelError("NumberOfGuests", $"Оставащи места в ресоранта {remainingCapacity}");
                return this.View(input);
            }

            var userId = await this.usersService.GetUserIdAsync(this.User);

            input.UserId = userId;

            await this.restaurantService.ReserveRestaurant(input);

            this.TempData["InfoMessage"] = "You successfully booked a restaurant!";

            return this.Redirect("/Restaurant/Reservations");
        }

        [HttpGet]
        public async Task<IActionResult> Reservations()
        {
            var userId = await this.usersService.GetUserIdAsync(this.User);

            var reservations = await this.restaurantService
                .GetAllReservationsAsync<RestaurantAllViewModel>(userId);

            var reservationView = new RestaurantViewModel()
            {
                AllReservations = reservations,
            };

            return this.View(reservationView);
        }
    }
}
