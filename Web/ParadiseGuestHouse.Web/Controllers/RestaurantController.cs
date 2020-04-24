namespace ParadiseGuestHouse.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using ParadiseGuestHouse.Data.Common.Repositories;
    using ParadiseGuestHouse.Data.Models;
    using ParadiseGuestHouse.Services.Data;
    using ParadiseGuestHouse.Web.InputModels.Restaurant;
    using ParadiseGuestHouse.Web.ViewModels.Restaurant;

    public class RestaurantController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IRestaurantService restaurantService;
        private readonly IDeletableEntityRepository<RestaurantReservation> restaurantReservationRepository;

        public RestaurantController(
            IUsersService usersService,
            IRestaurantService restaurantService,
            IDeletableEntityRepository<RestaurantReservation> restaurantReservationRepository)
        {
            this.usersService = usersService;
            this.restaurantService = restaurantService;
            this.restaurantReservationRepository = restaurantReservationRepository;
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

            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var userId = await this.usersService.GetUserIdAsync(this.User);

            input.UserId = userId;

            var result = await this.restaurantService.ReserveRestaurant(input);

            if (result == false)
            {
                this.ModelState.AddModelError("EventDate", $"Свободните места за тази дата са {remainingCapacity}");
                return this.View(input);
            }

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
