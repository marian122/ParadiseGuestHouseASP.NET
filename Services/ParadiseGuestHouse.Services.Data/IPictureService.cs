namespace ParadiseGuestHouse.Services.Data
{
    using System.Threading.Tasks;

    public interface IPictureService
    {
        Task<string> AddPictureAsync(string url);
    }
}
