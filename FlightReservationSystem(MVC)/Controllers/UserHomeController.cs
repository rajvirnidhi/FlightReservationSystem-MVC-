using FlightReservationSystem_MVC_.Data;
using FlightReservationSystem_MVC_.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationSystem_MVC_.Controllers
{
    public class UserHomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public User _user = new Models.User();

        public string _email="email";
        public UserHomeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(User user)
        {
            _user = user;
            _email = user.email;
            ViewBag.email = user.email;
            return RedirectToAction("ViewFlight", user);
        }

        public IActionResult ViewFlight(User user)
        {
            _user = user;
            IEnumerable<Flight> objFlightList = _db.FlightDetails;
            ViewBag.email = _user.email;
            return View(objFlightList);
        }

        public IActionResult Book(string? id, string? email)
        {
            if (id == null)
            {
                return NotFound();
            }
            _email= email;
            var userDetails = _db.User.Find(email);
            var flightDB = _db.FlightDetails.Find(id);
            Booking book = new Booking
            {
                flightid = id,
                name = flightDB.name,
                source = flightDB.source,
                destination = flightDB.destination,
                hours = flightDB.hours,
                seats = flightDB.seats,
                days = flightDB.days,
                cost = flightDB.cost,
                email = email,
                FName = userDetails.FName,
                LName = userDetails.LName,
                dob = userDetails.dob,
                gender = userDetails.gender,
                address = userDetails.address,
                password = userDetails.password,
                pno = userDetails.pno,
            };
            if (flightDB == null || userDetails == null)
            {
                return NotFound();
            }
            return View(book);
        }

        public IActionResult BookConfirm(string? id, string? email)
        {
            if (id == null || email == null)
            {
                return NotFound();
            }
            var userDetails = _db.User.Find(email);
            var flightDB = _db.FlightDetails.Find(id);
            Booking book = new Booking
            {
                flightid = id,
                name = flightDB.name,
                source = flightDB.source,
                destination = flightDB.destination,
                hours = flightDB.hours,
                seats = flightDB.seats,
                days = flightDB.days,
                cost = flightDB.cost,
                email = email,
                FName = userDetails.FName,
                LName = userDetails.LName,
                dob = userDetails.dob,
                gender = userDetails.gender,
                address = userDetails.address,
                password = userDetails.password,
                pno = userDetails.pno,
            };
            _db.Booking.Add(book);
            _db.SaveChanges();
            return RedirectToAction("ViewBooking", book);
            if (flightDB == null || userDetails == null)
            {
                return NotFound();
            }
            return RedirectToAction("ViewFlight", book);
        }

        public IActionResult ViewBooking(Booking book)
        {
            bool userExist = _db.Booking.Any(x => x.email == book.email);
            Booking userBooking = _db.Booking.FirstOrDefault(x => x.email == book.email);
            IEnumerable<Booking> objBookingList = _db.Booking;
            return View(objBookingList);
        }

        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var booking = _db.Booking.Find(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        public IActionResult DeletePOST(int id)
        {
            var obj = _db.Booking.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Booking.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("ViewBooking", obj);
        }

    }
}
