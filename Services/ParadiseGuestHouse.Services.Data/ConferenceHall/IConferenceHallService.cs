namespace ParadiseGuestHouse.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ParadiseGuestHouse.Data.Models;
    using ParadiseGuestHouse.Web.InputModels.ConferenceHall;

    public interface IConferenceHallService
    {
        Task<bool> ReserveConferenceHall(ConferenceHallInputModel input);

        Task<IEnumerable<TViewModel>> GetAllReservationsAsync<TViewModel>(string userId);

        Task<IEnumerable<TViewModel>> GetAllReservationsAsyncForAdmin<TViewModel>();

        Task<int> GetAllHallsAsync<TViewModel>(ConferenceHallInputModel input);
    }
}
