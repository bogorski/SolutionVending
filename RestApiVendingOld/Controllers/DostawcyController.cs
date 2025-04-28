using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiVending.ForView;
using RestApiVending.Model;
using RestApiVending.Model.Context;

namespace RestApiVending.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DostawcyController : ControllerBase
    {
        private readonly CompanyContext _context;

        public DostawcyController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/Dostawcy
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DostawcyForView>>> GetDostawcies()
        {
            return await _context.Dostawcies..Where(wrk => wrk.IsActive).ToListAsync())
                .Select(cli => (DostawcyForView)cli)
                .ToListAsync();
        }

        // GET: api/Dostawcy/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DostawcyForView>> GetDostawcy(int id)
        {
            var dostawcy = await _context.Dostawcies.FindAsync(id);

            if (dostawcy == null)
            {
                return NotFound();
            }

            return dostawcy;
        }

        // PUT: api/Dostawcy/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDostawcy(int id, DostawcyForView dostawcy)
        {
            if (id != dostawcy.Iddostawcy)
            {
                return BadRequest();
            }

            _context.Entry(dostawcy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DostawcyExists(id))
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

        // POST: api/Dostawcy
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DostawcyForView>> PostDostawcy(DostawcyForView dostawcy)
        {
            _context.Dostawcies.Add(dostawcy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDostawcy", new { id = dostawcy.Iddostawcy }, dostawcy);
        }

        // DELETE: api/Dostawcy/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDostawcy(int id)
        {
            var dostawcy = await _context.Dostawcies.FindAsync(id);
            if (dostawcy == null)
            {
                return NotFound();
            }

            _context.Dostawcies.Remove(dostawcy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DostawcyExists(int id)
        {
            return _context.Dostawcies.Any(e => e.Iddostawcy == id);
        }
    }
}
