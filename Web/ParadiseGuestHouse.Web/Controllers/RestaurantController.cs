namespace ParadiseGuestHouse.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ParadiseGuestHouse.Web.InputModels.Restaurant;

    public class RestaurantController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Reserve()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Reserve(RestaurantInputModel input)
        {
            return this.Json(input);
        }
    }
}
