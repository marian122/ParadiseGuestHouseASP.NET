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
        [EmailAddress(ErrorMessage = "Невалиден Имейл адрес!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Полето е задължително!")]
        [MaxLength(300, ErrorMessage = "Допустима дължина 300 символа.")]
        public string Message { get; set; }
    }
}
