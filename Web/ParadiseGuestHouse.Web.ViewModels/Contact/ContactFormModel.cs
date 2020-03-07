﻿namespace ParadiseGuestHouse.Web.ViewModels.Contact
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Microsoft.AspNetCore.Mvc;
    using PressCenters.Web.Infrastructure;

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
        [MaxLength(30, ErrorMessage = "Максимална дължина 30 символа.")]
        public string Title { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Максимална дължина 300 символа.")]
        public string Content { get; set; }

        //[GoogleReCaptchaValidation]
        //public string RecaptchaValue { get; set; }
    }
}
