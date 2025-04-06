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
    public class TypyMaszynController : ControllerBase
    {
        private readonly CompanyContext _context;

        public TypyMaszynController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/TypyMaszyn
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypyMaszyn>>> GetTypyMaszyns()
        {
            return await _context.TypyMaszyns.ToListAsync();
        }

        // GET: api/TypyMaszyn/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypyMaszyn>> GetTypyMaszyn(int id)
        {
            var typyMaszyn = await _context.TypyMaszyns.FindAsync(id);

            if (typyMaszyn == null)
            {
                return NotFound();
            }

            return typyMaszyn;
        }

        // PUT: api/TypyMaszyn/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypyMaszyn(int id, TypyMaszyn typyMaszyn)
        {
            if (id != typyMaszyn.IdtypMaszyny)
            {
                return BadRequest();
            }

            _context.Entry(typyMaszyn).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypyMaszynExists(id))
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

        // POST: api/TypyMaszyn
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypyMaszyn>> PostTypyMaszyn(TypyMaszyn typyMaszyn)
        {
            _context.TypyMaszyns.Add(typyMaszyn);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypyMaszyn", new { id = typyMaszyn.IdtypMaszyny }, typyMaszyn);
        }

        // DELETE: api/TypyMaszyn/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypyMaszyn(int id)
        {
            var typyMaszyn = await _context.TypyMaszyns.FindAsync(id);
            if (typyMaszyn == null)
            {
                return NotFound();
            }

            _context.TypyMaszyns.Remove(typyMaszyn);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypyMaszynExists(int id)
        {
            return _context.TypyMaszyns.Any(e => e.IdtypMaszyny == id);
        }
    }
}
