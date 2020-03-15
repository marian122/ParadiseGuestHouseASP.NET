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

        public ConfHallEventType ConfHallType { get; set; }

        public IList<Picture> Pictures { get; set; }

        public string Description { get; set; }

        public int Capacity { get; set; }

        public decimal Price { get; set; }

        public ICollection<ConferenceHallReservation> ConferenceHallReservations { get; set; }
    }
}
