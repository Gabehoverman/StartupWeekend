using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Startup_Weekend_Application.Data;
using Startup_Weekend_Application.Models;

namespace Startup_Weekend_Application.Controllers
{
    public class BeaconsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BeaconsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Beacons
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ping.ToListAsync());
        }

        // GET: Beacons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ping = await _context.Ping
                .SingleOrDefaultAsync(m => m.Id == id);
            if (ping == null)
            {
                return NotFound();
            }

            return View(ping);
        }

        // GET: Beacons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Beacons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Game,Time,Platform,PlayStyle,SkillLevel")] Ping ping)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ping);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ping);
        }

        // GET: Beacons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ping = await _context.Ping.SingleOrDefaultAsync(m => m.Id == id);
            if (ping == null)
            {
                return NotFound();
            }
            return View(ping);
        }

        // POST: Beacons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Username,Time,Game,Platform,PlayStyle,SkillLevel")] Ping ping)
        {
            if (id != ping.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ping);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PingExists(ping.Id))
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
            return View(ping);
        }

        // GET: Beacons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ping = await _context.Ping
                .SingleOrDefaultAsync(m => m.Id == id);
            if (ping == null)
            {
                return NotFound();
            }

            return View(ping);
        }

        // POST: Beacons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ping = await _context.Ping.SingleOrDefaultAsync(m => m.Id == id);
            _context.Ping.Remove(ping);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PingExists(int id)
        {
            return _context.Ping.Any(e => e.Id == id);
        }
    }
}
