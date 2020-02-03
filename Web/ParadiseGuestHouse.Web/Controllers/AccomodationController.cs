namespace ParadiseGuestHouse.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class AccomodationController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult SingleRoom()
        {
            return this.View();
        }
    }
}
