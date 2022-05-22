using FlightReservationSystem_MVC_.Data;
using FlightReservationSystem_MVC_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient; 
using System.Configuration;

namespace FlightReservationSystem_MVC_.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        public UserController(ApplicationDbContext db)
        {
            this ._db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        //GET
        public IActionResult Signup()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Signup(User obj)
        {
            //check if model is valid
            if (ModelState.IsValid)
            {
                _db.User.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(obj);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(User obj)
        {
            bool userExist = _db.User.Any(x => x.email == obj.email && x.password == obj.password);
            User user = _db.User.FirstOrDefault(x => x.email == obj.email && x.password == obj.password);
            if (userExist)
            {
                if(user.email == "admin@gmail.com")
                {
                    return RedirectToAction("Index", "Admin");
                }
                return RedirectToAction("Index", "UserHome",user);
            }
            ModelState.AddModelError("", "Username or password does not match");
            return View();
        }
    }
}
