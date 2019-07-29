using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VELogistics.Data;
using VELogistics.Models;

namespace VELogistics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoadsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LoadsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Loads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Load>>> GetLoad()
        {
            return await _context.Load.ToListAsync();
        }

        // GET: api/Loads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Load>> GetLoad(int id)
        {
            var load = await _context.Load.FindAsync(id);

            if (load == null)
            {
                return NotFound();
            }

            return load;
        }

        // PUT: api/Loads/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoad(int id, Load load)
        {
            if (id != load.LoadId)
            {
                return BadRequest();
            }

            _context.Entry(load).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoadExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Loads
        [HttpPost]
        public async Task<ActionResult<Load>> PostLoad(Load load)
        {
            _context.Load.Add(load);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoad", new { id = load.LoadId }, load);
        }

        // DELETE: api/Loads/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Load>> DeleteLoad(int id)
        {
            var load = await _context.Load.FindAsync(id);
            if (load == null)
            {
                return NotFound();
            }

            _context.Load.Remove(load);
            await _context.SaveChangesAsync();

            return load;
        }

        private bool LoadExists(int id)
        {
            return _context.Load.Any(e => e.LoadId == id);
        }
    }
}
