namespace ParadiseGuestHouse.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ParadiseGuestHouse.Data.Common.Models;
    using ParadiseGuestHouse.Data.Models.Enums;

    public class Room : BaseDeletableModel<string>
    {
        public Room()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Pictures = new HashSet<Picture>();
        }

        [Required]
        public virtual ICollection<Picture> Pictures { get; set; }

        [Required]
        public RoomType RoomType { get; set; }

        [Required]
        [Range(typeof(decimal), "1", "1000")]
        public decimal Price { get; set; }

        [Required]
        [Range(1, 10)]
        public int NumberOfBeds { get; set; }

        public bool HasBathroom { get; set; }

        public bool HasRoomService { get; set; }

        public bool HasSeaView { get; set; }

        public bool HasMountainView { get; set; }

        public bool HasWifi { get; set; }

        public bool HasTv { get; set; }

        public bool HasPhone { get; set; }

        public bool HasAirConditioner { get; set; }

        public bool HasHeater { get; set; }
    }
}
