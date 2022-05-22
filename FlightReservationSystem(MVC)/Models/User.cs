using System.ComponentModel.DataAnnotations;

namespace FlightReservationSystem_MVC_.Models
{
    public class User
    {
        //for primary key we need to add this annotation
        //[Key]
        //public int Id { get; set; }

        [Required] //name is required prperty
        public string FName { get; set; }

        [Required]
        public string LName { get; set; }

        [Key]
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
    }
}
