using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ParadiseGuestHouse.Services.Data
{
    public interface IUsersService
    {
        Task<string> GetUserIdAsync(ClaimsPrincipal claims);
    }
}
