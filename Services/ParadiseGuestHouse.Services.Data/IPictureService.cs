namespace ParadiseGuestHouse.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPictureService
    {
        Task<string> AddPictureAsync(string url);
    }
}
