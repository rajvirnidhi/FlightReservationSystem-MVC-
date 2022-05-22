using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightReservationSystem_MVC_.Models
{
    public class Booking
    {
        [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }

        [Required] //name is required prperty
        public string FName { get; set; }

        [Required]
        public string LName { get; set; }

        public string email { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public DateTime dob { get; set; }

        [Required]
        public string gender { get; set; }

        [Required]
        public string address { get; set; }

        [Required]
        public int pno { get; set; }
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
    }
}
