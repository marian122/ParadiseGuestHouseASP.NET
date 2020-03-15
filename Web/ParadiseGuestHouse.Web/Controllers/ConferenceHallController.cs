﻿namespace ParadiseGuestHouse.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using ParadiseGuestHouse.Services.Data;
    using ParadiseGuestHouse.Web.InputModels.ConferenceHall;
    using ParadiseGuestHouse.Web.ViewModels.ConferenceHall;

    public class ConferenceHallController : Controller
    {
        private readonly IConferenceHallService conferenceHallService;
        private readonly IUsersService usersService;

        public ConferenceHallController(IConferenceHallService conferenceHallService, IUsersService usersService)
        {
            this.conferenceHallService = conferenceHallService;
            this.usersService = usersService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Reserve()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Reserve(ConferenceHallInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var userId = await this.usersService.GetUserIdAsync(this.User);

            input.UserId = userId;

            await this.conferenceHallService.ReserveConferenceHall(input);

            return this.Redirect("/ConferenceHall/Reservations");
        }

        [HttpGet]
        public async Task<IActionResult> Reservations()
        {
            var userId = await this.usersService.GetUserIdAsync(this.User);

            var reservations = await this.conferenceHallService
                .GetAllReservationsAsync<ConfHallAllViewModel>(userId);

            var reservationView = new ConfHallViewModel()
            {
                AllReservations = reservations,
            };

            return this.View(reservationView);
        }
    }
}
