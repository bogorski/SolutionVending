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
    public class PracowniciesController : ControllerBase
    {
        private readonly CompanyContext _context;

        public PracowniciesController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/Pracownicies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pracownicy>>> GetPracownicies()
        {
            return await _context.Pracownicies.ToListAsync();
        }

        // GET: api/Pracownicies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pracownicy>> GetPracownicy(int id)
        {
            var pracownicy = await _context.Pracownicies.FindAsync(id);

            if (pracownicy == null)
            {
                return NotFound();
            }

            return pracownicy;
        }

        // PUT: api/Pracownicies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPracownicy(int id, Pracownicy pracownicy)
        {
            if (id != pracownicy.Idpracownika)
            {
                return BadRequest();
            }

            _context.Entry(pracownicy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PracownicyExists(id))
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

        // POST: api/Pracownicies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pracownicy>> PostPracownicy(Pracownicy pracownicy)
        {
            _context.Pracownicies.Add(pracownicy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPracownicy", new { id = pracownicy.Idpracownika }, pracownicy);
        }

        // DELETE: api/Pracownicies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePracownicy(int id)
        {
            var pracownicy = await _context.Pracownicies.FindAsync(id);
            if (pracownicy == null)
            {
                return NotFound();
            }

            _context.Pracownicies.Remove(pracownicy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PracownicyExists(int id)
        {
            return _context.Pracownicies.Any(e => e.Idpracownika == id);
        }
    }
}
