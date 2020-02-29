namespace ParadiseGuestHouse.Web.InputModels
{
    using System.ComponentModel.DataAnnotations;

    using ParadiseGuestHouse.Data.Models.Enums;

    public class CreateRoomInputModel
    {
        [Required(ErrorMessage = "Полето е задължително")]
        public RoomType RoomType { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Полето е задължително")]
        [Range(1, 10, ErrorMessage = "Броят на леглата трябва да е между 1 и 10")]
        public int NumberOfBeds { get; set; }

        public bool HasBathroom { get; set; }

        public bool HasRoomService { get; set; }

        public bool HasSeaView { get; set; }

        public bool HasMountainView { get; set; }

        public bool HasWifi { get; set; }

        public bool HasTv { get; set; }

        public bool HasPhone { get; set; }

        public bool HasAirConditioner { get; set; }

        public bool HasHeater { get; set; }
    }
}
