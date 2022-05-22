using Microsoft.AspNetCore.Mvc;

namespace FlightReservationSystem_MVC_.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
