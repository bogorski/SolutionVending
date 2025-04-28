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
    public class StanowiskaPraciesController : ControllerBase
    {
        private readonly CompanyContext _context;

        public StanowiskaPraciesController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/StanowiskaPracies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StanowiskaPracy>>> GetStanowiskaPracies()
        {
            return await _context.StanowiskaPracies.ToListAsync();
        }

        // GET: api/StanowiskaPracies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StanowiskaPracy>> GetStanowiskaPracy(int id)
        {
            var stanowiskaPracy = await _context.StanowiskaPracies.FindAsync(id);

            if (stanowiskaPracy == null)
            {
                return NotFound();
            }

            return stanowiskaPracy;
        }

        // PUT: api/StanowiskaPracies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStanowiskaPracy(int id, StanowiskaPracy stanowiskaPracy)
        {
            if (id != stanowiskaPracy.IdstanowiskaPracy)
            {
                return BadRequest();
            }

            _context.Entry(stanowiskaPracy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StanowiskaPracyExists(id))
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

        // POST: api/StanowiskaPracies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StanowiskaPracy>> PostStanowiskaPracy(StanowiskaPracy stanowiskaPracy)
        {
            _context.StanowiskaPracies.Add(stanowiskaPracy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStanowiskaPracy", new { id = stanowiskaPracy.IdstanowiskaPracy }, stanowiskaPracy);
        }

        // DELETE: api/StanowiskaPracies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStanowiskaPracy(int id)
        {
            var stanowiskaPracy = await _context.StanowiskaPracies.FindAsync(id);
            if (stanowiskaPracy == null)
            {
                return NotFound();
            }

            _context.StanowiskaPracies.Remove(stanowiskaPracy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StanowiskaPracyExists(int id)
        {
            return _context.StanowiskaPracies.Any(e => e.IdstanowiskaPracy == id);
        }
    }
}
