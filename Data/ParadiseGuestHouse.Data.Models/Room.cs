namespace ParadiseGuestHouse.Data.Models
{
    using ParadiseGuestHouse.Data.Common.Models;
    using ParadiseGuestHouse.Data.Models.Enums;

    public class Room : BaseDeletableModel<int>
    {
        public virtual RoomType RoomType { get; set; }

        public decimal Price { get; set; }

        public Picture Picture { get; set; }

        public RoomDescription RoomDescription { get; set; }
    }
}
