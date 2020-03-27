namespace ParadiseGuestHouse.Web.ViewModels.Feedback
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using ParadiseGuestHouse.Data.Models;
    using ParadiseGuestHouse.Services.Mapping;

    public class FeedbackViewModel
    {
        public IEnumerable<AllFeedbackViewModel> AllFeedbacks { get; set; }
    }
}
