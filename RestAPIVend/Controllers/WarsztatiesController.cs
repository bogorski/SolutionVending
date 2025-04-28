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
    public class WarsztatiesController : ControllerBase
    {
        private readonly CompanyContext _context;

        public WarsztatiesController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/Warsztaties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Warsztaty>>> GetWarsztaties()
        {
            return await _context.Warsztaties.ToListAsync();
        }

        // GET: api/Warsztaties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Warsztaty>> GetWarsztaty(int id)
        {
            var warsztaty = await _context.Warsztaties.FindAsync(id);

            if (warsztaty == null)
            {
                return NotFound();
            }

            return warsztaty;
        }

        // PUT: api/Warsztaties/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWarsztaty(int id, Warsztaty warsztaty)
        {
            if (id != warsztaty.Idwarsztatu)
            {
                return BadRequest();
            }

            _context.Entry(warsztaty).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WarsztatyExists(id))
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

        // POST: api/Warsztaties
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Warsztaty>> PostWarsztaty(Warsztaty warsztaty)
        {
            _context.Warsztaties.Add(warsztaty);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWarsztaty", new { id = warsztaty.Idwarsztatu }, warsztaty);
        }

        // DELETE: api/Warsztaties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWarsztaty(int id)
        {
            var warsztaty = await _context.Warsztaties.FindAsync(id);
            if (warsztaty == null)
            {
                return NotFound();
            }

            _context.Warsztaties.Remove(warsztaty);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WarsztatyExists(int id)
        {
            return _context.Warsztaties.Any(e => e.Idwarsztatu == id);
        }
    }
}
