namespace ParadiseGuestHouse.Data.Models
{
    public class ReservedRestaurant
    {
        public string RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }

        public string RestaurantReservationId { get; set; }

        public RestaurantReservation RestaurantReservation { get; set; }
    }
}
