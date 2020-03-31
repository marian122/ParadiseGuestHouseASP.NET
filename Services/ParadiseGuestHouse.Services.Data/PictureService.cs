namespace ParadiseGuestHouse.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

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
                throw new InvalidOperationException("Exception happened in PictureService while saving the Picture in IDeletableEntityRepository<Picture>");
            }
            else
            {
                return picture.Id;
            }
        }
    }
}
