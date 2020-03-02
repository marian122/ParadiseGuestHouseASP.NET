namespace ParadiseGuestHouse.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ParadiseGuestHouse.Data.Models.Enums;

    public interface IRoomsService
    {
        Task<bool> CreateRoom(RoomType roomType, decimal price, int numberOfBeds, bool hasBathroom, bool hasRoomService, bool hasSeaView, bool hasMountainView, bool hasWifi, bool hasTv, bool hasPhone, bool hasAirConditioner, bool hasHeater);

        Task<bool> DeleteRoom(string id);

        Task<IEnumerable<TViewModel>> GetAllRoomsAsync<TViewModel>();

        Task<TViewModel> GetRoomAsync<TViewModel>(string id);
    }
}
