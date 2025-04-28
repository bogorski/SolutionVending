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
    public class PracownikTowaryController : ControllerBase
    {
        private readonly CompanyContext _context;

        public PracownikTowaryController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/PracownikTowary
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PracownikTowary>>> GetPracownikTowaries()
        {
            return await _context.PracownikTowaries.ToListAsync();
        }

        // GET: api/PracownikTowary/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PracownikTowary>> GetPracownikTowary(int id)
        {
            var pracownikTowary = await _context.PracownikTowaries.FindAsync(id);

            if (pracownikTowary == null)
            {
                return NotFound();
            }

            return pracownikTowary;
        }

        // PUT: api/PracownikTowary/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPracownikTowary(int id, PracownikTowary pracownikTowary)
        {
            if (id != pracownikTowary.Idpracownika)
            {
                return BadRequest();
            }

            _context.Entry(pracownikTowary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PracownikTowaryExists(id))
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

        // POST: api/PracownikTowary
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PracownikTowary>> PostPracownikTowary(PracownikTowary pracownikTowary)
        {
            _context.PracownikTowaries.Add(pracownikTowary);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PracownikTowaryExists(pracownikTowary.Idpracownika))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPracownikTowary", new { id = pracownikTowary.Idpracownika }, pracownikTowary);
        }

        // DELETE: api/PracownikTowary/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePracownikTowary(int id)
        {
            var pracownikTowary = await _context.PracownikTowaries.FindAsync(id);
            if (pracownikTowary == null)
            {
                return NotFound();
            }

            _context.PracownikTowaries.Remove(pracownikTowary);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PracownikTowaryExists(int id)
        {
            return _context.PracownikTowaries.Any(e => e.Idpracownika == id);
        }
    }
}
