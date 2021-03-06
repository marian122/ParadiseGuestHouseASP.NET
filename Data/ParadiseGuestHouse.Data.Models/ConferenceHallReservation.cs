﻿namespace ParadiseGuestHouse.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using ParadiseGuestHouse.Data.Common.Models;
    using ParadiseGuestHouse.Data.Models.Enums;

    public class ConferenceHallReservation : BaseDeletableModel<string>
    {
        public ConferenceHallReservation()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [Range(1, 100)]
        public int NumberOfGuests { get; set; }

        public decimal TotalPrice { get; set; }

        [Required]
        public ConfHallEventType EventType { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime CheckIn { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime CheckOut { get; set; }

        public string ConferenceHallId { get; set; }

        public ConferenceHall ConferenceHall { get; set; }

        [MaxLength(300)]
        public string Message { get; set; }
    }
}
