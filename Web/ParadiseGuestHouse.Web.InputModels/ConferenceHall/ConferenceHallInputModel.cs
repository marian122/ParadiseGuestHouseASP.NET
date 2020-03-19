namespace ParadiseGuestHouse.Web.InputModels.ConferenceHall
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using ParadiseGuestHouse.Common;
    using ParadiseGuestHouse.Data.Models.Enums;

    public class ConferenceHallInputModel
    {
        [MaxLength(20, ErrorMessage = GlobalConstants.UserNameMaxLength)]
        public string FirstName { get; set; }

        [MaxLength(20, ErrorMessage = GlobalConstants.UserNameMaxLength)]
        public string LastName { get; set; }

        public string UserId { get; set; }

        [EmailAddress(ErrorMessage = GlobalConstants.InvalidEmail)]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredField)]
        [Phone(ErrorMessage = GlobalConstants.InvalidPhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredField)]
        [Range(0, 100, ErrorMessage = GlobalConstants.ConfHallReserveGuestsMax)]
        public int NumberOfGuests { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredField)]
        public ConfHallEventType EventType { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredField)]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredField)]
        [DataType(DataType.Time)]
        public DateTime CheckIn { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredField)]
        [DataType(DataType.Time)]
        public DateTime CheckOut { get; set; }

        [MaxLength(300, ErrorMessage = GlobalConstants.ContentMessageMaxLength)]
        public string Message { get; set; }
    }
}
