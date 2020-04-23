namespace ParadiseGuestHouse.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ParadiseGuestHouse.Data.Models;
    using ParadiseGuestHouse.Data.Models.Enums;
    using ParadiseGuestHouse.Web.InputModels.Room;
    using ParadiseGuestHouse.Web.ViewModels.Room;

    public interface IRoomsService
    {
        Task<bool> CreateRoom(CreateRoomInputModel input);

        Task<bool> EditRoomAsync(string id, EditRoomViewModel input);

        Task<bool> DeleteRoom(string id);

        Task<IEnumerable<TViewModel>> GetAllRoomsAsync<TViewModel>();

        Task<TViewModel> GetRoomAsync<TViewModel>(string id);

        Task<EditRoomViewModel> GetRoomForEditAsync(string id);

        Task<IEnumerable<TViewModel>> GetAllReservationsAsync<TViewModel>(string userId);

        Task<IEnumerable<TViewModel>> GetAllReservationsAsyncForAdmin<TViewModel>();

        Task<bool> ReserveRoom(ReserveRoomInputModel input);

        Room GetRoomById(string id);
    }
}
