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
    public class LokalizacjesController : ControllerBase
    {
        private readonly CompanyContext _context;

        public LokalizacjesController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/Lokalizacjes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lokalizacje>>> GetLokalizacjes()
        {
            return await _context.Lokalizacjes.ToListAsync();
        }

        // GET: api/Lokalizacjes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lokalizacje>> GetLokalizacje(int id)
        {
            var lokalizacje = await _context.Lokalizacjes.FindAsync(id);

            if (lokalizacje == null)
            {
                return NotFound();
            }

            return lokalizacje;
        }

        // PUT: api/Lokalizacjes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLokalizacje(int id, Lokalizacje lokalizacje)
        {
            if (id != lokalizacje.Idlokalizacji)
            {
                return BadRequest();
            }

            _context.Entry(lokalizacje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LokalizacjeExists(id))
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

        // POST: api/Lokalizacjes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lokalizacje>> PostLokalizacje(Lokalizacje lokalizacje)
        {
            _context.Lokalizacjes.Add(lokalizacje);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLokalizacje", new { id = lokalizacje.Idlokalizacji }, lokalizacje);
        }

        // DELETE: api/Lokalizacjes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLokalizacje(int id)
        {
            var lokalizacje = await _context.Lokalizacjes.FindAsync(id);
            if (lokalizacje == null)
            {
                return NotFound();
            }

            _context.Lokalizacjes.Remove(lokalizacje);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LokalizacjeExists(int id)
        {
            return _context.Lokalizacjes.Any(e => e.Idlokalizacji == id);
        }
    }
}
