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
    public class TowaryController : ControllerBase
    {
        private readonly CompanyContext _context;

        public TowaryController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/Towary
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Towary>>> GetTowaries()
        {
            return await _context.Towaries.ToListAsync();
        }

        // GET: api/Towary/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Towary>> GetTowary(int id)
        {
            var towary = await _context.Towaries.FindAsync(id);

            if (towary == null)
            {
                return NotFound();
            }

            return towary;
        }

        // PUT: api/Towary/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTowary(int id, Towary towary)
        {
            if (id != towary.Idtowaru)
            {
                return BadRequest();
            }

            _context.Entry(towary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TowaryExists(id))
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

        // POST: api/Towary
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Towary>> PostTowary(Towary towary)
        {
            _context.Towaries.Add(towary);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTowary", new { id = towary.Idtowaru }, towary);
        }

        // DELETE: api/Towary/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTowary(int id)
        {
            var towary = await _context.Towaries.FindAsync(id);
            if (towary == null)
            {
                return NotFound();
            }

            _context.Towaries.Remove(towary);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TowaryExists(int id)
        {
            return _context.Towaries.Any(e => e.Idtowaru == id);
        }
    }
}
