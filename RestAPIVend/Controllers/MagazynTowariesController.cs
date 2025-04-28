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
    public class MagazynTowariesController : ControllerBase
    {
        private readonly CompanyContext _context;

        public MagazynTowariesController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/MagazynTowaries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MagazynTowary>>> GetMagazynTowaries()
        {
            return await _context.MagazynTowaries.ToListAsync();
        }

        // GET: api/MagazynTowaries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MagazynTowary>> GetMagazynTowary(int id)
        {
            var magazynTowary = await _context.MagazynTowaries.FindAsync(id);

            if (magazynTowary == null)
            {
                return NotFound();
            }

            return magazynTowary;
        }

        // PUT: api/MagazynTowaries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMagazynTowary(int id, MagazynTowary magazynTowary)
        {
            if (id != magazynTowary.Idmagazynu)
            {
                return BadRequest();
            }

            _context.Entry(magazynTowary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MagazynTowaryExists(id))
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

        // POST: api/MagazynTowaries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MagazynTowary>> PostMagazynTowary(MagazynTowary magazynTowary)
        {
            _context.MagazynTowaries.Add(magazynTowary);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MagazynTowaryExists(magazynTowary.Idmagazynu))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMagazynTowary", new { id = magazynTowary.Idmagazynu }, magazynTowary);
        }

        // DELETE: api/MagazynTowaries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMagazynTowary(int id)
        {
            var magazynTowary = await _context.MagazynTowaries.FindAsync(id);
            if (magazynTowary == null)
            {
                return NotFound();
            }

            _context.MagazynTowaries.Remove(magazynTowary);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MagazynTowaryExists(int id)
        {
            return _context.MagazynTowaries.Any(e => e.Idmagazynu == id);
        }
    }
}
