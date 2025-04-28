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
    public class MagazyniesController : ControllerBase
    {
        private readonly CompanyContext _context;

        public MagazyniesController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/Magazynies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Magazyny>>> GetMagazynies()
        {
            return await _context.Magazynies.ToListAsync();
        }

        // GET: api/Magazynies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Magazyny>> GetMagazyny(int id)
        {
            var magazyny = await _context.Magazynies.FindAsync(id);

            if (magazyny == null)
            {
                return NotFound();
            }

            return magazyny;
        }

        // PUT: api/Magazynies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMagazyny(int id, Magazyny magazyny)
        {
            if (id != magazyny.Idmagazynu)
            {
                return BadRequest();
            }

            _context.Entry(magazyny).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MagazynyExists(id))
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

        // POST: api/Magazynies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Magazyny>> PostMagazyny(Magazyny magazyny)
        {
            _context.Magazynies.Add(magazyny);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMagazyny", new { id = magazyny.Idmagazynu }, magazyny);
        }

        // DELETE: api/Magazynies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMagazyny(int id)
        {
            var magazyny = await _context.Magazynies.FindAsync(id);
            if (magazyny == null)
            {
                return NotFound();
            }

            _context.Magazynies.Remove(magazyny);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MagazynyExists(int id)
        {
            return _context.Magazynies.Any(e => e.Idmagazynu == id);
        }
    }
}
