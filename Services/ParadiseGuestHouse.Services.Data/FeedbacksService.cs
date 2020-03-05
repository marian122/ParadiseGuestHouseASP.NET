namespace ParadiseGuestHouse.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using ParadiseGuestHouse.Data.Common.Repositories;
    using ParadiseGuestHouse.Data.Models;

    public class FeedbacksService : IFeedbacksService
    {
        private readonly IDeletableEntityRepository<Feedback> repository;

        public FeedbacksService(IDeletableEntityRepository<Feedback> repository)
        {
            this.repository = repository;
        }

        public async Task<bool> SendFeedback(string firstName,string lastName, string message)
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
    }
}
