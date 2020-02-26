namespace ParadiseGuestHouse.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using ParadiseGuestHouse.Data.Common.Models;

    public class Picture : BaseDeletableModel<int>
    {
        [Required]
        public string Link { get; set; }
    }
}