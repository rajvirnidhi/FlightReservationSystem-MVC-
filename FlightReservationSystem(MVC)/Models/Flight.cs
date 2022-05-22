using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FlightReservationSystem_MVC_.Models
{
    public class Flight
    {
        [Key]
        public string flightid { get; set; }
        [DisplayName("Flight id")]
        [Required]
        public string name { get; set; }
        [DisplayName("Flight name")]
        [Required]
        public string source { get; set; }
        [DisplayName("Source")]
        [Required]
        public string destination { get; set; }
        [DisplayName("Destination")]
        [Required]
        public double hours { get; set; }
        [DisplayName("Flight hours")]
        [Required]
        public int seats { get; set; }
        [DisplayName("Seating capacity")]
        [Required]
        public string days { get; set; }
        [DisplayName("Flight days")]
        [Required]
        public double cost { get; set; }
        //[DisplayName("Flight cost per seat")]
        
    }
}
