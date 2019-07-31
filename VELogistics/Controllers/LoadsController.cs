using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VELogistics.Data;
using VELogistics.Models;
using VELogistics.Models.ViewModel;

namespace VELogistics.Controllers
{
    public class LoadsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoadsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Loads
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var applicationDbContext =
                _context.Load
                        .Include(l => l.Driver);
                       

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
                .Include(l => l.Driver)
                .FirstOrDefaultAsync(m => m.LoadId == id);
            if (load == null)
            {
                return NotFound();
            }

            return View(load);
        }

        // GET: Loads/Create
        public async Task<IActionResult> Create()
        {
            var viewModel = new LoadCreateViewModel
            {
                AvailableDrivers = await _context.Driver.ToListAsync(),
            };
            return View(viewModel);
        }

        // POST: Loads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LoadCreateViewModel viewModel)
        {
            // NOTE: Ignore any ModelState errors for a particular property by "removing" it's key
            //       Since we are using a ViewModel, the ModelState Keys 
            //       MUST include the ViewModels' Book property
            ModelState.Remove("Load.Driver");
            ModelState.Remove("Load.User");
            ModelState.Remove("Load.UserId");

            if (ModelState.IsValid)
            {
                var Load = viewModel.Load;
                var currentUser = await _userManager.GetUserAsync(HttpContext.User);
                Load.LoadId = currentUser.UserTypeId;
                _context.Add(Load);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            viewModel.AvailableDrivers = await _context.Driver.ToListAsync();
            return View(viewModel);
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
