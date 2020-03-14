namespace ParadiseGuestHouse.Web.InputModels.Room
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class ReserveRoomInputModel
    {
        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(20)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Имейл адреса е задължителен")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Тел. номер е задължителен")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Броят на гостите е задължителен")]
        [Range(0, 20, ErrorMessage = "Максималния брой гости е 20.")]
        public int CountOfPeople { get; set; }

        [Required(ErrorMessage = "Датата на настаняване е задължителна")]
        public DateTime CheckIn { get; set; }

        [Required(ErrorMessage = "Датата на напускане е задължителна")]
        public DateTime CheckOut { get; set; }

        [MaxLength(300, ErrorMessage = "Допустима дължина 300 символа!")]
        public string Message { get; set; }

        public string RoomId { get; set; }

        public string UserId { get; set; }

    }
}
