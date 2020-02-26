namespace ParadiseGuestHouse.Data.Models
{
    using System.Collections.Generic;

    using ParadiseGuestHouse.Data.Common.Models;
    using ParadiseGuestHouse.Data.Models.Enums;

    public class RoomDescription : BaseDeletableModel<int>
    {
        public RoomType RoomType { get; set; }

        public IEnumerable<Picture> Pictures { get; set; }

        public string Description { get; set; }
    }
}
