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
    public class DostawaTowariesController : ControllerBase
    {
        private readonly CompanyContext _context;

        public DostawaTowariesController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/DostawaTowaries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DostawaTowary>>> GetDostawaTowaries()
        {
            return await _context.DostawaTowaries.ToListAsync();
        }

        // GET: api/DostawaTowaries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DostawaTowary>> GetDostawaTowary(int id)
        {
            var dostawaTowary = await _context.DostawaTowaries.FindAsync(id);

            if (dostawaTowary == null)
            {
                return NotFound();
            }

            return dostawaTowary;
        }

        // PUT: api/DostawaTowaries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDostawaTowary(int id, DostawaTowary dostawaTowary)
        {
            if (id != dostawaTowary.Idtowaru)
            {
                return BadRequest();
            }

            _context.Entry(dostawaTowary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DostawaTowaryExists(id))
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

        // POST: api/DostawaTowaries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DostawaTowary>> PostDostawaTowary(DostawaTowary dostawaTowary)
        {
            _context.DostawaTowaries.Add(dostawaTowary);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DostawaTowaryExists(dostawaTowary.Idtowaru))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDostawaTowary", new { id = dostawaTowary.Idtowaru }, dostawaTowary);
        }

        // DELETE: api/DostawaTowaries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDostawaTowary(int id)
        {
            var dostawaTowary = await _context.DostawaTowaries.FindAsync(id);
            if (dostawaTowary == null)
            {
                return NotFound();
            }

            _context.DostawaTowaries.Remove(dostawaTowary);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DostawaTowaryExists(int id)
        {
            return _context.DostawaTowaries.Any(e => e.Idtowaru == id);
        }
    }
}
