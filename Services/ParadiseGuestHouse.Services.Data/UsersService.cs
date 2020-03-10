using Microsoft.AspNetCore.Identity;
using ParadiseGuestHouse.Data.Common.Repositories;
using ParadiseGuestHouse.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ParadiseGuestHouse.Services.Data
{
    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> context;
        private readonly UserManager<ApplicationUser> userManager;

        public UsersService(IDeletableEntityRepository<ApplicationUser> context, UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task<string> GetUserIdAsync(ClaimsPrincipal claims)
        {
            ApplicationUser uID = await this.userManager.GetUserAsync(claims);

            return uID.Id;
        }
    }
}
