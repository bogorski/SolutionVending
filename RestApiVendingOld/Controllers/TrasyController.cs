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
    public class TrasyController : ControllerBase
    {
        private readonly CompanyContext _context;

        public TrasyController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/Trasy
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trasy>>> GetTrasies()
        {
            return await _context.Trasies.ToListAsync();
        }

        // GET: api/Trasy/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trasy>> GetTrasy(int id)
        {
            var trasy = await _context.Trasies.FindAsync(id);

            if (trasy == null)
            {
                return NotFound();
            }

            return trasy;
        }

        // PUT: api/Trasy/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrasy(int id, Trasy trasy)
        {
            if (id != trasy.Idtrasy)
            {
                return BadRequest();
            }

            _context.Entry(trasy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrasyExists(id))
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

        // POST: api/Trasy
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trasy>> PostTrasy(Trasy trasy)
        {
            _context.Trasies.Add(trasy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrasy", new { id = trasy.Idtrasy }, trasy);
        }

        // DELETE: api/Trasy/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrasy(int id)
        {
            var trasy = await _context.Trasies.FindAsync(id);
            if (trasy == null)
            {
                return NotFound();
            }

            _context.Trasies.Remove(trasy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrasyExists(int id)
        {
            return _context.Trasies.Any(e => e.Idtrasy == id);
        }
    }
}
