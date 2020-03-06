namespace ParadiseGuestHouse.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using ParadiseGuestHouse.Data.Common.Repositories;
    using ParadiseGuestHouse.Data.Models;
    using ParadiseGuestHouse.Services.Mapping;

    public class FeedbacksService : IFeedbacksService
    {
        private readonly IDeletableEntityRepository<Feedback> repository;

        public FeedbacksService(IDeletableEntityRepository<Feedback> repository)
        {
            this.repository = repository;
        }

        public async Task<bool> SendFeedback(string firstName, string lastName, string message)
        {
            var feedback = new Feedback()
            {
                FirstName = firstName,
                LastName = lastName,
                Message = message,
            };

            await this.repository.AddAsync(feedback);

            var result = await this.repository.SaveChangesAsync();

            return result > 0;
        }

        public async Task<IEnumerable<TViewModel>> GetAllFeedbacksAsync<TViewModel>()
            => await this.repository.All()
            .Where(f => f.IsDeleted == false)
            .OrderBy(d => d.CreatedOn)
            .To<TViewModel>()
            .ToListAsync();

        public async Task<TViewModel> GetFeedbackAsync<TViewModel>(string id)
            => await this.repository
            .All()
            .Where(r => r.Id == id && r.IsDeleted != true)
            .To<TViewModel>()
            .FirstOrDefaultAsync();

        public async Task<bool> DeleteFeedback(string id)
        {
            var feedback = this.repository.All()
                .FirstOrDefault(f => f.Id == id);

            if (feedback != null)
            {
                this.repository.Delete(feedback);

                var result = await this.repository.SaveChangesAsync();

                return result > 0;
            }

            throw new NullReferenceException();
        }
    }
}
