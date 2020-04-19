namespace ParadiseGuestHouse.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ParadiseGuestHouse.Web.InputModels.Restaurant;

    public interface IRestaurantService
    {
        Task<bool> ReserveRestaurant(RestaurantInputModel input);

        Task<IEnumerable<TViewModel>> GetAllReservationsAsync<TViewModel>(string userId);

        Task<IEnumerable<TViewModel>> GetAllReservationsAsyncForAdmin<TViewModel>();
    }
}
