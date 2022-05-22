using FlightReservationSystem_MVC_.Models;

namespace FlightReservationSystem_MVC_.Data
{
    public class UserDAO
    {
        private string connectionString = @"Server=NIDHI-RAJVIR\\SQLEXPRESS;Database=FlightReservationSystem;Trusted_Connection=True;";

        public List<User> FetchAll()
        {
            List<User> list = new List<User>();
             
            return list;
        }
    }
}
