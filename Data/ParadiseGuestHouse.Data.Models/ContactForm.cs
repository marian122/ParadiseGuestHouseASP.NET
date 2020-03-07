namespace ParadiseGuestHouse.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using ParadiseGuestHouse.Data.Common.Models;

    public class ContactForm : BaseDeletableModel<string>
    {
        public ContactForm()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(20, ErrorMessage = "Максимална дължина 20 символа.")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Максимална дължина 20 символа.")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Невалиден имейл адрес.")]
        public string Email { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Максимална дължина 30 символа.")]
        public string Title { get; set; }

        [Required]
        [MaxLength(300, ErrorMessage = "Максимална дължина 300 символа.")]
        public string Content { get; set; }

        public string Ip { get; set; }
    }
}
