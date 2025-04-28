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
    public class FakturiesController : ControllerBase
    {
        private readonly CompanyContext _context;

        public FakturiesController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/Fakturies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Faktury>>> GetFakturies()
        {
            return await _context.Fakturies.ToListAsync();
        }

        // GET: api/Fakturies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Faktury>> GetFaktury(int id)
        {
            var faktury = await _context.Fakturies.FindAsync(id);

            if (faktury == null)
            {
                return NotFound();
            }

            return faktury;
        }

        // PUT: api/Fakturies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFaktury(int id, Faktury faktury)
        {
            if (id != faktury.Idfaktury)
            {
                return BadRequest();
            }

            _context.Entry(faktury).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FakturyExists(id))
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

        // POST: api/Fakturies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Faktury>> PostFaktury(Faktury faktury)
        {
            _context.Fakturies.Add(faktury);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFaktury", new { id = faktury.Idfaktury }, faktury);
        }

        // DELETE: api/Fakturies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFaktury(int id)
        {
            var faktury = await _context.Fakturies.FindAsync(id);
            if (faktury == null)
            {
                return NotFound();
            }

            _context.Fakturies.Remove(faktury);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FakturyExists(int id)
        {
            return _context.Fakturies.Any(e => e.Idfaktury == id);
        }
    }
}
