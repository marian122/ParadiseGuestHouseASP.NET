namespace ParadiseGuestHouse.Services.Data
{
    using System.Threading.Tasks;

    public interface IFeedbacksService
    {
        Task<bool> SendFeedback(string firstName, string lastName, string message);
    }
}
