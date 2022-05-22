using FlightReservationSystem_MVC_.Data;
using FlightReservationSystem_MVC_.Models;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservationSystem_MVC_.Controllers
{
    public class FlightController : Controller
    {
        private readonly ApplicationDbContext _db;
        public FlightController(ApplicationDbContext db)
        {
            this._db = db;
        }
        public IActionResult AddFlight()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddFlight(Flight obj)
        {
            //check if model is valid
            if (ModelState.IsValid)
            {
                _db.FlightDetails.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("UpdateFlight");
            }
            return View(obj);
        }

        public IActionResult UpdateFlight()
        {
            IEnumerable<Flight> objFlightList = _db.FlightDetails;
            return View(objFlightList);
        }

        public IActionResult Edit(string? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var flightDB = _db.FlightDetails.Find(id);
            FlightEdit flightEdit  = new FlightEdit
            {
                flightid = id,
                name = flightDB.name,
                source = flightDB.source,
                destination = flightDB.destination,
                hours = flightDB.hours,
                seats = flightDB.seats,
                days = flightDB.days,
                cost = flightDB.cost,
            };
            if (flightDB == null)
            {
                return NotFound();
            }
            return View(flightEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FlightEdit obj)
        {
            //check if model is valid
            if (ModelState.IsValid)
            {
                var flightDB = _db.FlightDetails.Find(obj.flightid);
                flightDB.name = obj.name;
                flightDB.source = obj.source;
                flightDB.destination = obj.destination;
                flightDB.hours = obj.hours;
                flightDB.days = obj.days;
                flightDB.cost = obj.cost;
                flightDB.seats = obj.seats;
                _db.FlightDetails.Update(flightDB);
                _db.SaveChanges();
                return RedirectToAction("UpdateFlight");
            }
            return View(obj);
        }


        public IActionResult Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var flightDB = _db.FlightDetails.Find(id);
            if (flightDB == null)
            {
                return NotFound();
            }
            return View(flightDB);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(string? flightid)
        {
            var obj = _db.FlightDetails.Find(flightid);
            if (obj == null)
            {
                return NotFound();
            }
            _db.FlightDetails.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("UpdateFlight");
        }
    }
}
