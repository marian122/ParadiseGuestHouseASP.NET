namespace ParadiseGuestHouse.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using ParadiseGuestHouse.Data.Common.Models;

    public class Restaurant : BaseDeletableModel<string>
    {
        public Restaurant()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Pictures = new List<Picture>();
        }

        public IList<Picture> Pictures { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
