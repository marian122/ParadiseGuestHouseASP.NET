namespace ParadiseGuestHouse.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using ParadiseGuestHouse.Services.Data;
    using ParadiseGuestHouse.Web.InputModels.Feedback;

    public class FeedbackController : Controller
    {
        private readonly IFeedbacksService feedbackService;

        public FeedbackController(IFeedbacksService feedbackService)
        {
            this.feedbackService = feedbackService;
        }

        public async Task<IActionResult> Send(FeedbackInputModel input)
        {
            await this.feedbackService.SendFeedback(input.FirstName, input.LastName, input.Message);

            return this.Redirect("/");
        }
    }
}
