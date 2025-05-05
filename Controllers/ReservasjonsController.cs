using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hotel.Data;
using Hotel.Models;

namespace Hotel.Controllers
{
    public class ReservasjonsController : Controller
    {
        private readonly HotelContext _context;

        public ReservasjonsController(HotelContext context)
        {
            _context = context;
        }

        // GET: Reservasjons
        public async Task<IActionResult> Index()
        {
            var hotelContext = _context.Reservasjon.Include(r => r.Room);
            return View(await hotelContext.ToListAsync());
        }

        // GET: Reservasjons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservasjon = await _context.Reservasjon
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.ReservasjonsId == id);
            if (reservasjon == null)
            {
                return NotFound();
            }

            return View(reservasjon);
        }

        // GET: Reservasjons/Create
        public IActionResult Create()
        {
            ViewData["RoomId"] = new SelectList(_context.Room, "Id", "Id");
            return View();
        }

        // POST: Reservasjons/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReservasjonsId,FirstName,LastName,StartDate,endDate,RoomId")] Reservasjon reservasjon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservasjon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoomId"] = new SelectList(_context.Room, "Id", "Id", reservasjon.RoomId);
            return View(reservasjon);
        }

        // GET: Reservasjons/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservasjon = await _context.Reservasjon.FindAsync(id);
            if (reservasjon == null)
            {
                return NotFound();
            }
            ViewData["RoomId"] = new SelectList(_context.Room, "Id", "Id", reservasjon.RoomId);
            return View(reservasjon);
        }

        // POST: Reservasjons/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReservasjonsId,FirstName,LastName,StartDate,endDate,RoomId")] Reservasjon reservasjon)
        {
            if (id != reservasjon.ReservasjonsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservasjon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservasjonExists(reservasjon.ReservasjonsId))
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
            ViewData["RoomId"] = new SelectList(_context.Room, "Id", "Id", reservasjon.RoomId);
            return View(reservasjon);
        }

        // GET: Reservasjons/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservasjon = await _context.Reservasjon
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.ReservasjonsId == id);
            if (reservasjon == null)
            {
                return NotFound();
            }

            return View(reservasjon);
        }

        // POST: Reservasjons/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservasjon = await _context.Reservasjon.FindAsync(id);
            if (reservasjon != null)
            {
                _context.Reservasjon.Remove(reservasjon);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservasjonExists(int id)
        {
            return _context.Reservasjon.Any(e => e.ReservasjonsId == id);
        }
    }
}
