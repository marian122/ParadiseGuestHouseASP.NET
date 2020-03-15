using ParadiseGuestHouse.Web.InputModels.ConferenceHall;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParadiseGuestHouse.Services.Data
{
    public interface IConferenceHallService
    {
        Task<bool> ReserveConferenceHall(ConferenceHallInputModel input);

        Task<IEnumerable<TViewModel>> GetAllReservationsAsync<TViewModel>(string userId);
    }
}
