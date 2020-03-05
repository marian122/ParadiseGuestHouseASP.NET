namespace ParadiseGuestHouse.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using ParadiseGuestHouse.Data.Common.Models;

    public class Feedback : BaseDeletableModel<string>
    {
        public Feedback()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required(ErrorMessage = "Полето е задължително!")]
        [MaxLength(20, ErrorMessage = "Максимална дължина 20 символа.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Полето е задължително!")]
        [MaxLength(20, ErrorMessage = "Максимална дължина 20 символа.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Полето е задължително!")]
        [MaxLength(300, ErrorMessage = "Максимална дължина 300 символа.")]
        public string Message { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string GuestId { get; set; }

        public Guest Guest { get; set; }

    }
}
