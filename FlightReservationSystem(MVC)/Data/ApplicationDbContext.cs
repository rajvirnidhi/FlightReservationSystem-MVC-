using FlightReservationSystem_MVC_.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationSystem_MVC_.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }

        public DbSet<Flight> FlightDetails { get; set; }

        public DbSet<Booking> Booking { get; set; }
        public DbSet<Models.Route> Route { get; set; }
    }
}
