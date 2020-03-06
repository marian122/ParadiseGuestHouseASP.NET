namespace ParadiseGuestHouse.Services.Data
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IFeedbacksService
    {
        Task<bool> SendFeedback(string firstName, string lastName, string message);

        Task<IEnumerable<TViewModel>> GetAllFeedbacksAsync<TViewModel>();

        Task<TViewModel> GetFeedbackAsync<TViewModel>(string id);

        Task<bool> DeleteFeedback(string id);
    }
}
