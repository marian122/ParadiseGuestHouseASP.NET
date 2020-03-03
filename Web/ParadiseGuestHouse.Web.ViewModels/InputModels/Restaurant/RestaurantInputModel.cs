namespace ParadiseGuestHouse.Web.ViewModels.InputModels.Restaurant
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class RestaurantInputModel
    {
        [Required(ErrorMessage = "Полето е задължително")]
        [MaxLength(20, ErrorMessage = "Полето може да съдържа най-много 20 символа")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [MaxLength(20, ErrorMessage = "Полето може да съдържа най-много 20 символа")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [EmailAddress(ErrorMessage = "Невалиден имейл!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [RegularExpression(@"08[789]\d{7}", ErrorMessage = "Грешен телефонен номер")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [Range(0, 120, ErrorMessage = "Полето трябва де бъде между 0 и 120")]
        public int NumberOfPeople { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [DataType(DataType.Date)]
        public DateTime DateOfMeeting { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [DataType(DataType.Time)]
        public DateTime StartingHour { get; set; }

        public string Message { get; set; }
    }
}
