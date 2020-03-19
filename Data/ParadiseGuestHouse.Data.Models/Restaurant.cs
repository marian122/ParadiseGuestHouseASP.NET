﻿namespace ParadiseGuestHouse.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ParadiseGuestHouse.Data.Common.Models;

    public class Restaurant : BaseDeletableModel<string>
    {
        public Restaurant()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Pictures = new List<Picture>();
            this.RestaurantReservations = new HashSet<RestaurantReservation>();
        }

        public IList<Picture> Pictures { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [Range(0, 120)]
        public int CurrentCapacity { get; set; }

        [Required]
        [Range(0, 120)]
        public int MaxCapacity { get; set; }

        public ICollection<RestaurantReservation> RestaurantReservations { get; set; }
    }
}
