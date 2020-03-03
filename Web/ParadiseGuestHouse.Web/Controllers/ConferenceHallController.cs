namespace ParadiseGuestHouse.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using ParadiseGuestHouse.Web.ViewModels.InputModels.ConferenceHall;

    public class ConferenceHallController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Reserve()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Reserve(ConferenceHallInputModel input)
        {
            return this.Json(input);
        }
    }
}
