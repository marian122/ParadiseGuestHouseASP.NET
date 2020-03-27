namespace ParadiseGuestHouse.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using ParadiseGuestHouse.Data.Common.Repositories;
    using ParadiseGuestHouse.Data.Models;
    using ParadiseGuestHouse.Data.Models.Enums;

    public class RatingsService : IRatingsService
    {
        private readonly IRepository<Rating> ratingsRepository;

        public RatingsService(IRepository<Rating> ratingsRepository)
        {
            this.ratingsRepository = ratingsRepository;
        }

        public int GetRatings()
        {
            var votes = this.ratingsRepository.All().Sum(x => (int)x.RatingType);
            return votes;
        }

        public async Task RatingAsync(string userId, bool isUpVote)
        {
            var vote = this.ratingsRepository.All()
                .FirstOrDefault(x => x.UserId == userId);
            if (vote != null)
            {
                vote.RatingType = isUpVote ? RatingType.Positive : RatingType.Negative;
            }
            else
            {
                vote = new Rating
                {
                    UserId = userId,
                    RatingType = isUpVote ? RatingType.Positive : RatingType.Negative,
                };

                await this.ratingsRepository.AddAsync(vote);
            }

            await this.ratingsRepository.SaveChangesAsync();
        }
    }
}
