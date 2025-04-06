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
    public class MaszynaTowaryController : ControllerBase
    {
        private readonly CompanyContext _context;

        public MaszynaTowaryController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/MaszynaTowary
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaszynaTowary>>> GetMaszynaTowaries()
        {
            return await _context.MaszynaTowaries.ToListAsync();
        }

        // GET: api/MaszynaTowary/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaszynaTowary>> GetMaszynaTowary(string id)
        {
            var maszynaTowary = await _context.MaszynaTowaries.FindAsync(id);

            if (maszynaTowary == null)
            {
                return NotFound();
            }

            return maszynaTowary;
        }

        // PUT: api/MaszynaTowary/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaszynaTowary(string id, MaszynaTowary maszynaTowary)
        {
            if (id != maszynaTowary.NumerMaszyny)
            {
                return BadRequest();
            }

            _context.Entry(maszynaTowary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaszynaTowaryExists(id))
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

        // POST: api/MaszynaTowary
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MaszynaTowary>> PostMaszynaTowary(MaszynaTowary maszynaTowary)
        {
            _context.MaszynaTowaries.Add(maszynaTowary);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MaszynaTowaryExists(maszynaTowary.NumerMaszyny))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMaszynaTowary", new { id = maszynaTowary.NumerMaszyny }, maszynaTowary);
        }

        // DELETE: api/MaszynaTowary/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaszynaTowary(string id)
        {
            var maszynaTowary = await _context.MaszynaTowaries.FindAsync(id);
            if (maszynaTowary == null)
            {
                return NotFound();
            }

            _context.MaszynaTowaries.Remove(maszynaTowary);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MaszynaTowaryExists(string id)
        {
            return _context.MaszynaTowaries.Any(e => e.NumerMaszyny == id);
        }
    }
}
