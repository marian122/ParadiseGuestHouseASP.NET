﻿namespace ParadiseGuestHouse.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using ParadiseGuestHouse.Data.Common.Models;
    using ParadiseGuestHouse.Data.Models.Enums;

    public class RestaurantReservation : BaseDeletableModel<string>
    {
        public RestaurantReservation()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [Range(1, 100)]
        public int NumberOfGuests { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public RestaurantEventType EventType { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        [Required]
        public DateTime CheckIn { get; set; }

        [Required]
        public DateTime CheckOut { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        [MaxLength(300)]
        public string Message { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}
