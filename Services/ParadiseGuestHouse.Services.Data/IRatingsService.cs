using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParadiseGuestHouse.Services.Data
{
    public interface IRatingsService
    {
        Task RatingAsync(string userId, bool isUpVote);

        int GetRatings();
    }
}
