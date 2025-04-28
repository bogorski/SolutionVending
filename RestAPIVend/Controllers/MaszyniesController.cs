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
    public class MaszyniesController : ControllerBase
    {
        private readonly CompanyContext _context;

        public MaszyniesController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/Maszynies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Maszyny>>> GetMaszynies()
        {
            return await _context.Maszynies.ToListAsync();
        }

        // GET: api/Maszynies/5
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

        // PUT: api/Maszynies/5
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

        // POST: api/Maszynies
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

        // DELETE: api/Maszynies/5
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
