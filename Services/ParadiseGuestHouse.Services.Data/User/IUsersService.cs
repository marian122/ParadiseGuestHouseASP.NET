namespace ParadiseGuestHouse.Services.Data
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    public interface IUsersService
    {
        Task<string> GetUserIdAsync(ClaimsPrincipal claims);

        Task<string> GetUserPhoneNumberAsync(ClaimsPrincipal claims);
    }
}
