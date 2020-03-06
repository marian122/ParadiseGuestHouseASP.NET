namespace ParadiseGuestHouse.Web.ViewModels.Contact
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Microsoft.AspNetCore.Mvc;

    public class ContactFormModel
    {
        [Required]
        [MaxLength(20, ErrorMessage = "Максимална дължина 20 символа.")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Максимална дължина 20 символа.")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Невалиден имей адрес.")]
        public string Email { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Максимална дължина 300 символа.")]
        public string Message { get; set; }
    }
}
