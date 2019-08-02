using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VELogistics.Data;
using VELogistics.Models;

namespace VELogistics.Controllers
{
    [Authorize]
    public class LoadsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private object buttonSearch;

        public object AcceptButton { get; private set; }

        public LoadsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        // GET: Loads
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Load.Include(l => l.Driver).Include(l => l.UserType);
            return View(await applicationDbContext.ToListAsync());
        }

        //Adding a search bar for Loads

        public async Task<IActionResult> Search(string searchLoad)
        {
            var loadSearch = from l in _context.Load
                                 select l;

            if (!String.IsNullOrEmpty(searchLoad))
            {
                loadSearch = loadSearch.Where(s => s.UserType.Name.Contains(searchLoad));
            }

            //Allows for enter keypress
            this.AcceptButton = this.buttonSearch;

            return View(await loadSearch.ToListAsync());
        }


        // GET: Loads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var load = await _context.Load
                .Include(l => l.Driver)
                .Include(l => l.UserType)
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
            ViewData["DriverId"] = new SelectList(_context.Driver, "Id", "FullName");
            ViewData["UserTypeId"] = new SelectList(_context.UserType, "Id", "Name");
            return View();
        }

        // POST: Loads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoadId,Amount,PickupDate,DeliverdDate,Location,DriverId,UserTypeId")] Load load)
        {
            if (ModelState.IsValid)
            {
                _context.Add(load);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DriverId"] = new SelectList(_context.Driver, "Id", "FullName", load.DriverId);
            ViewData["UserTypeId"] = new SelectList(_context.UserType, "Id", "Name", load.UserTypeId);
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
            ViewData["DriverId"] = new SelectList(_context.Driver, "Id", "FirstName", load.DriverId);
            ViewData["UserTypeId"] = new SelectList(_context.UserType, "Id", "Name", load.UserTypeId);
            return View(load);
        }

        // POST: Loads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LoadId,Amount,PickupDate,DeliverdDate,Location,DriverId,UserTypeId")] Load load)
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
            ViewData["DriverId"] = new SelectList(_context.Driver, "Id", "FirstName", load.DriverId);
            ViewData["UserTypeId"] = new SelectList(_context.UserType, "Id", "Name", load.UserTypeId);
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
                .Include(l => l.Driver)
                .Include(l => l.UserType)
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
