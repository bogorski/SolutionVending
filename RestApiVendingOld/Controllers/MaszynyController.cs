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
    public class MaszynyController : ControllerBase
    {
        private readonly CompanyContext _context;

        public MaszynyController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/Maszyny
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Maszyny>>> GetMaszynies()
        {
            return await _context.Maszynies.ToListAsync();
        }

        // GET: api/Maszyny/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Maszyny>> GetMaszyny(string id)
        {
            var maszyny = await _context.Maszynies.FindAsync(id);

            if (maszyny == null)
            {
                return NotFound();
            }

            return maszyny;
        }

        // PUT: api/Maszyny/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaszyny(string id, Maszyny maszyny)
        {
            if (id != maszyny.NumerMaszyny)
            {
                return BadRequest();
            }

            _context.Entry(maszyny).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaszynyExists(id))
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

        // POST: api/Maszyny
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Maszyny>> PostMaszyny(Maszyny maszyny)
        {
            _context.Maszynies.Add(maszyny);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MaszynyExists(maszyny.NumerMaszyny))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMaszyny", new { id = maszyny.NumerMaszyny }, maszyny);
        }

        // DELETE: api/Maszyny/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaszyny(string id)
        {
            var maszyny = await _context.Maszynies.FindAsync(id);
            if (maszyny == null)
            {
                return NotFound();
            }

            _context.Maszynies.Remove(maszyny);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MaszynyExists(string id)
        {
            return _context.Maszynies.Any(e => e.NumerMaszyny == id);
        }
    }
}
