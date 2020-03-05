namespace ParadiseGuestHouse.Services.Data
{
    using System.Threading.Tasks;

    public interface IFeedbackService
    {
        Task<bool> SendFeedback(string email, string message);
    }
}
