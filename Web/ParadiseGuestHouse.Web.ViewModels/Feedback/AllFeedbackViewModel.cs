namespace ParadiseGuestHouse.Web.ViewModels.Feedback
{
    using ParadiseGuestHouse.Data.Models;
    using ParadiseGuestHouse.Services.Mapping;

    public class AllFeedbackViewModel : IMapFrom<Feedback>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Message { get; set; }

        public bool IsApproved { get; set; }
    }
}
