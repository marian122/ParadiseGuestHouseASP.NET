namespace ParadiseGuestHouse.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using ParadiseGuestHouse.Data.Common.Models;
    using ParadiseGuestHouse.Data.Models.Enums;

    public class ConferenceHall : BaseDeletableModel<string>
    {
        public ConferenceHall()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Pictures = new List<Picture>();
        }

        public IList<Picture> Pictures { get; set; }

        public EventType EventType { get; set; }

        public string Description { get; set; }
    }
}
