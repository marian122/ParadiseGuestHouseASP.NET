namespace ParadiseGuestHouse.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using ParadiseGuestHouse.Services.Data;
    using ParadiseGuestHouse.Web.ViewModels;
    using ParadiseGuestHouse.Web.ViewModels.Feedback;

    public class HomeController : BaseController
    {
        private readonly IFeedbacksService feedbacksService;

        public HomeController(IFeedbacksService feedbacksService)
        {
            this.feedbacksService = feedbacksService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var feedbacks = await this.feedbacksService
                .GetAllFeedbacksAsync<AllFeedbackViewModel>();

            var feedback = new FeedbackViewModel()
            {
                AllFeedbacks = feedbacks,
            };

            return this.View(feedback);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
