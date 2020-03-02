using System.ComponentModel.DataAnnotations;

namespace ParadiseGuestHouse.Data.Models.Enums
{

    public enum RoomType
    {
        [Display(Name = "Edinichna")]
        SingleRoom = 1,
        DoubleRoom = 2,
        Apartment = 3,
    }
}
