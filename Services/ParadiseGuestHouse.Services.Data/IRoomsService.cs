namespace ParadiseGuestHouse.Services.Data
{
    using ParadiseGuestHouse.Data.Models.Enums;
    using System.Threading.Tasks;

    public interface IRoomsService
    {
        Task<bool> CreateRoom(RoomType roomType, decimal price, int numberOfBeds, bool hasBathroom, bool hasRoomService, bool hasSeaView, bool hasMountainView, bool hasWifi, bool hasTv, bool hasPhone, bool hasAirConditioner, bool hasHeater);
    }
}
