namespace ParadiseGuestHouse.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ParadiseGuestHouse.Web.InputModels.ConferenceHall;

    public interface IConferenceHallService
    {
        Task<bool> ReserveConferenceHall(ConferenceHallInputModel input);

        Task<IEnumerable<TViewModel>> GetAllReservationsAsync<TViewModel>(string userId);

        Task<IEnumerable<TViewModel>> GetAllReservationsAsyncForAdmin<TViewModel>();
    }
}
