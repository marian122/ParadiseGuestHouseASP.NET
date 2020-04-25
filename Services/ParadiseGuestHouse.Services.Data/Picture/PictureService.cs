namespace ParadiseGuestHouse.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using ParadiseGuestHouse.Common;
    using ParadiseGuestHouse.Data.Common.Repositories;
    using ParadiseGuestHouse.Data.Models;

    public class PictureService : IPictureService
    {
        private readonly IDeletableEntityRepository<Picture> pictures;

        public PictureService(IDeletableEntityRepository<Picture> pictures)
        {
            this.pictures = pictures;
        }

        public async Task<string> AddPictureAsync(string url)
        {
            var picture = new Picture() { Url = url };

            await this.pictures.AddAsync(picture);
            var result = await this.pictures.SaveChangesAsync();

            if (result < 0)
            {
                throw new InvalidOperationException(GlobalConstants.InvalidOperationExceptionInPictureService);
            }
            else
            {
                return picture.Id;
            }
        }
    }
}
