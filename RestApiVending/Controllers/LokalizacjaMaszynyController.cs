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
    public class LokalizacjaMaszynyController : ControllerBase
    {
        private readonly CompanyContext _context;

        public LokalizacjaMaszynyController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/LokalizacjaMaszyny
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LokalizacjaMaszyny>>> GetLokalizacjaMaszynies()
        {
            return await _context.LokalizacjaMaszynies.ToListAsync();
        }

        // GET: api/LokalizacjaMaszyny/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LokalizacjaMaszyny>> GetLokalizacjaMaszyny(int id)
        {
            var lokalizacjaMaszyny = await _context.LokalizacjaMaszynies.FindAsync(id);

            if (lokalizacjaMaszyny == null)
            {
                return NotFound();
            }

            return lokalizacjaMaszyny;
        }

        // PUT: api/LokalizacjaMaszyny/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLokalizacjaMaszyny(int id, LokalizacjaMaszyny lokalizacjaMaszyny)
        {
            if (id != lokalizacjaMaszyny.IdLokalizacji)
            {
                return BadRequest();
            }

            _context.Entry(lokalizacjaMaszyny).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LokalizacjaMaszynyExists(id))
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

        // POST: api/LokalizacjaMaszyny
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LokalizacjaMaszyny>> PostLokalizacjaMaszyny(LokalizacjaMaszyny lokalizacjaMaszyny)
        {
            _context.LokalizacjaMaszynies.Add(lokalizacjaMaszyny);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LokalizacjaMaszynyExists(lokalizacjaMaszyny.IdLokalizacji))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLokalizacjaMaszyny", new { id = lokalizacjaMaszyny.IdLokalizacji }, lokalizacjaMaszyny);
        }

        // DELETE: api/LokalizacjaMaszyny/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLokalizacjaMaszyny(int id)
        {
            var lokalizacjaMaszyny = await _context.LokalizacjaMaszynies.FindAsync(id);
            if (lokalizacjaMaszyny == null)
            {
                return NotFound();
            }

            _context.LokalizacjaMaszynies.Remove(lokalizacjaMaszyny);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LokalizacjaMaszynyExists(int id)
        {
            return _context.LokalizacjaMaszynies.Any(e => e.IdLokalizacji == id);
        }
    }
}
