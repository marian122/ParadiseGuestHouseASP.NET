namespace ParadiseGuestHouse.Web.ViewModels.InputModels.Feedback
{
    using System.ComponentModel.DataAnnotations;

    public class FeedbackInputModel
    {
        [Required(ErrorMessage = "Полето е задължително!")]
        [MaxLength(20, ErrorMessage = "Максимална дължина 20 символа.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Полето е задължително!")]
        [MaxLength(20, ErrorMessage = "Максимална дължина 20 символа.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Полето е задължително!")]
        [MaxLength(300, ErrorMessage = "Максимална дължина 300 символа.")]
        public string Message { get; set; }
    }
}
