namespace ParadiseGuestHouse.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using ParadiseGuestHouse.Services.Data;

    public class FeedbackController : Controller
    {
        private readonly IFeedbacksService feedbackService;

        public FeedbackController(IFeedbacksService feedbackService)
        {
            this.feedbackService = feedbackService;
        }

        public async Task<IActionResult> DeleteFeedback(string feedbackId)
        {
            var result = await this.feedbackService.DeleteFeedback(feedbackId);

            if (result == true)
            {
                return this.Redirect("/");
            }

            return this.NotFound();
        }

        public async Task<IActionResult> ApproveFeedback(string feedbackId)
        {
            var result = await this.feedbackService.ApproveFeedback(feedbackId);

            if (result == true)
            {
                return this.Redirect("/");
            }

            return this.NotFound();
        }
    }
}