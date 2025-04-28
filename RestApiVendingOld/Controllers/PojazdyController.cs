using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiVending.Model;
using RestApiVending.Model.Context;

namespace RestApiVending.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PojazdyController : ControllerBase
    {
        private readonly CompanyContext _context;

        public PojazdyController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/Pojazdy
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pojazdy>>> GetPojazdies()
        {
            return await _context.Pojazdies.ToListAsync();
        }

        // GET: api/Pojazdy/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pojazdy>> GetPojazdy(int id)
        {
            var pojazdy = await _context.Pojazdies.FindAsync(id);

            if (pojazdy == null)
            {
                return NotFound();
            }

            return pojazdy;
        }

        // PUT: api/Pojazdy/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPojazdy(int id, Pojazdy pojazdy)
        {
            if (id != pojazdy.Idpojazdu)
            {
                return BadRequest();
            }

            _context.Entry(pojazdy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PojazdyExists(id))
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

        // POST: api/Pojazdy
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pojazdy>> PostPojazdy(Pojazdy pojazdy)
        {
            _context.Pojazdies.Add(pojazdy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPojazdy", new { id = pojazdy.Idpojazdu }, pojazdy);
        }

        // DELETE: api/Pojazdy/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePojazdy(int id)
        {
            var pojazdy = await _context.Pojazdies.FindAsync(id);
            if (pojazdy == null)
            {
                return NotFound();
            }

            _context.Pojazdies.Remove(pojazdy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PojazdyExists(int id)
        {
            return _context.Pojazdies.Any(e => e.Idpojazdu == id);
        }
    }
}
