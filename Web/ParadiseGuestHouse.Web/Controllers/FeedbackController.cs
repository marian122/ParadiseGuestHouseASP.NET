namespace ParadiseGuestHouse.Web.Controllers
{
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

            this.TempData["InfoMessage"] = "Thank you for your feedback!";

            return this.Redirect("/");
        }
    }
}
