namespace ParadiseGuestHouse.Web.ViewModels.InputModels.Feedback
{
    using System.ComponentModel.DataAnnotations;

    public class FeedbackInputModel
    {
        [Required(ErrorMessage = "Полето е задължително!")]
        [EmailAddress(ErrorMessage = "Невалиден Имейл адрес!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Полето е задължително!")]
        [MaxLength(300, ErrorMessage = "Допустима дължина 300 символа.")]
        public string Message { get; set; }
    }
}
