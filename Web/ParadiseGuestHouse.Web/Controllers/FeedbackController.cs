namespace ParadiseGuestHouse.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using ParadiseGuestHouse.Web.ViewModels.InputModels.Feedback;

    public class FeedbackController : Controller
    {
        public IActionResult Send(FeedbackInputModel input)
        {
            return this.Json(input);
        }
    }
}
