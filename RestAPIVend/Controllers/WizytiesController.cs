using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPIVend.Model;
using RestAPIVend.Model.Context;

namespace RestAPIVend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WizytiesController : ControllerBase
    {
        private readonly CompanyContext _context;

        public WizytiesController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/Wizyties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wizyty>>> GetWizyties()
        {
            return await _context.Wizyties.ToListAsync();
        }

        // GET: api/Wizyties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wizyty>> GetWizyty(int id)
        {
            var wizyty = await _context.Wizyties.FindAsync(id);

            if (wizyty == null)
            {
                return NotFound();
            }

            return wizyty;
        }

        // PUT: api/Wizyties/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWizyty(int id, Wizyty wizyty)
        {
            if (id != wizyty.Idwizyty)
            {
                return BadRequest();
            }

            _context.Entry(wizyty).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WizytyExists(id))
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

        // POST: api/Wizyties
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Wizyty>> PostWizyty(Wizyty wizyty)
        {
            _context.Wizyties.Add(wizyty);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWizyty", new { id = wizyty.Idwizyty }, wizyty);
        }

        // DELETE: api/Wizyties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWizyty(int id)
        {
            var wizyty = await _context.Wizyties.FindAsync(id);
            if (wizyty == null)
            {
                return NotFound();
            }

            _context.Wizyties.Remove(wizyty);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WizytyExists(int id)
        {
            return _context.Wizyties.Any(e => e.Idwizyty == id);
        }
    }
}
