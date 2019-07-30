﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VELogistics.Data;
using VELogistics.Models;

namespace VELogistics.Controllers
{
    public class LoadsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoadsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Loads
        public async Task<IActionResult> Index()
        {
            return View(await _context.Load.ToListAsync());
        }

        // GET: Loads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var load = await _context.Load
                .FirstOrDefaultAsync(m => m.LoadId == id);
            if (load == null)
            {
                return NotFound();
            }

            return View(load);
        }

        // GET: Loads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Loads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoadId,Customer,Carrier,Amount,PickupDate,DeliverdDate,Location,DriverId,UserId")] Load load)
        {
            if (ModelState.IsValid)
            {
                _context.Add(load);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(load);
        }

        // GET: Loads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var load = await _context.Load.FindAsync(id);
            if (load == null)
            {
                return NotFound();
            }
            return View(load);
        }

        // POST: Loads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LoadId,Customer,Carrier,Amount,PickupDate,DeliverdDate,Location,DriverId,UserId")] Load load)
        {
            if (id != load.LoadId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(load);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoadExists(load.LoadId))
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
            return View(load);
        }

        // GET: Loads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var load = await _context.Load
                .FirstOrDefaultAsync(m => m.LoadId == id);
            if (load == null)
            {
                return NotFound();
            }

            return View(load);
        }

        // POST: Loads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var load = await _context.Load.FindAsync(id);
            _context.Load.Remove(load);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoadExists(int id)
        {
            return _context.Load.Any(e => e.LoadId == id);
        }
    }
}
