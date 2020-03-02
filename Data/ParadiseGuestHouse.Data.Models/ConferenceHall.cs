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
            this.ConferenceHallReservations = new HashSet<ConferenceHallReservation>();
        }

        public IList<Picture> Pictures { get; set; }

        public string Description { get; set; }

        public ICollection<ConferenceHallReservation> ConferenceHallReservations { get; set; }
    }
}
