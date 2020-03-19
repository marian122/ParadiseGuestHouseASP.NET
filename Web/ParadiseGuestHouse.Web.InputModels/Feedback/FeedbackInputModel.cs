namespace ParadiseGuestHouse.Web.InputModels.Feedback
{
    using System.ComponentModel.DataAnnotations;

    using ParadiseGuestHouse.Common;

    public class FeedbackInputModel
    {
        [Required(ErrorMessage = GlobalConstants.RequiredField)]
        [MaxLength(20, ErrorMessage = GlobalConstants.UserNameMaxLength)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredField)]
        [MaxLength(20, ErrorMessage = GlobalConstants.UserNameMaxLength)]
        public string LastName { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredField)]
        [MaxLength(300, ErrorMessage = GlobalConstants.ContentMessageMaxLength)]
        public string Message { get; set; }
    }
}
