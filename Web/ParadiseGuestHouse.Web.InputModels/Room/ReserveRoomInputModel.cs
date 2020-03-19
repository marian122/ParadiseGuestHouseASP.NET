namespace ParadiseGuestHouse.Web.InputModels.Room
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using ParadiseGuestHouse.Common;

    public class ReserveRoomInputModel
    {
        [MaxLength(20, ErrorMessage = GlobalConstants.UserNameMaxLength)]
        public string FirstName { get; set; }

        [MaxLength(20)]
        public string LastName { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredField)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredField)]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredField)]
        [Range(0, 10, ErrorMessage = GlobalConstants.CountOfPeopleInRoomLength)]
        public int CountOfPeople { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredField)]
        public DateTime CheckIn { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredField)]
        public DateTime CheckOut { get; set; }

        [Required(ErrorMessage = GlobalConstants.RequiredField)]
        [MaxLength(300, ErrorMessage = GlobalConstants.ContentMessageMaxLength)]
        public string Message { get; set; }

        public string RoomId { get; set; }

        public string UserId { get; set; }

    }
}
