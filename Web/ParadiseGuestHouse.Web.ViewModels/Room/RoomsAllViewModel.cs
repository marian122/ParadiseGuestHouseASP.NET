namespace ParadiseGuestHouse.Web.ViewModels.Room
{
    using ParadiseGuestHouse.Data.Models;
    using ParadiseGuestHouse.Services.Mapping;

    public class RoomsAllViewModel : IMapFrom<Room>
    {
        public string RoomType { get; set; }

        public decimal Price { get; set; }

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

        //public IList<Picture> Pictures { get; set; }
    }
}
