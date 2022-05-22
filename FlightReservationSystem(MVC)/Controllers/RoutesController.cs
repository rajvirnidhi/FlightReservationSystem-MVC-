using FlightReservationSystem_MVC_.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightReservationSystem_MVC_.Controllers
{
    public class RoutesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public RoutesController(ApplicationDbContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Models.Route> objRouteList = _db.Route;
            return View(objRouteList);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _db.Route == null)
            {
                return NotFound();
            }

            var route = await _db.Route
                .FirstOrDefaultAsync(m => m.RouteID == id);
            if (route == null)
            {
                return NotFound();
            }

            return View(route);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RouteID,FromRoute,ToRoute")] Models.Route route)
        {
            if (ModelState.IsValid)
            {
                _db.Add(route);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(route);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _db.Route == null)
            {
                return NotFound();
            }

            var route = await _db.Route.FindAsync(id);
            if (route == null)
            {
                return NotFound();
            }
            return View(route);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RouteID,FromRoute,ToRoute")] Models.Route route)
        {
            if (id != route.RouteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(route);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RouteExists(route.RouteID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(route);
        }

        // GET: Routes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _db.Route == null)
            {
                return NotFound();
            }

            var route = await _db.Route
                .FirstOrDefaultAsync(m => m.RouteID == id);
            if (route == null)
            {
                return NotFound();
            }

            return View(route);
        }

        // POST: Routes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_db.Route == null)
            {
                return Problem("Entity set 'RouteDetails1Context.Route'  is null.");
            }
            var route = await _db.Route.FindAsync(id);
            if (route != null)
            {
                _db.Route.Remove(route);
            }

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RouteExists(int id)
        {
            return (_db.Route?.Any(e => e.RouteID == id)).GetValueOrDefault();
        }
    }
}
