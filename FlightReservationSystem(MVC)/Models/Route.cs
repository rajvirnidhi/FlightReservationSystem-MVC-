using System.ComponentModel.DataAnnotations;

namespace FlightReservationSystem_MVC_.Models
{
    public class Route
    {
        [Key]
        public int RouteID { get; set; }

        [Required]
        public string FromRoute { get; set; }

        [Required]
        public string ToRoute { get; set; }
    }
}
