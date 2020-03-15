namespace ParadiseGuestHouse.Web.InputModels.ConferenceHall
{
    using ParadiseGuestHouse.Data.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class ConferenceHallInputModel
    {
        [MaxLength(20, ErrorMessage = "Полето може да съдържа най-много 20 символа")]
        public string FirstName { get; set; }

        [MaxLength(20, ErrorMessage = "Полето може да съдържа най-много 20 символа")]
        public string LastName { get; set; }

        public string UserId { get; set; }

        [EmailAddress(ErrorMessage = "Невалиден имейл!")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [RegularExpression(@"08[789]\d{7}", ErrorMessage = "Грешен телефонен номер")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [Range(0, 200, ErrorMessage = "Полето трябва де бъде между 0 и 200")]
        public int NumberOfGuests { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        public ConfHallEventType EventType { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [DataType(DataType.Time)]
        public DateTime CheckIn { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [DataType(DataType.Time)]
        public DateTime CheckOut { get; set; }

        [MaxLength(300)]
        public string Message { get; set; }

    }
}
