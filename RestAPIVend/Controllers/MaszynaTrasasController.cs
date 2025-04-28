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
    public class MaszynaTrasasController : ControllerBase
    {
        private readonly CompanyContext _context;

        public MaszynaTrasasController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/MaszynaTrasas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaszynaTrasa>>> GetMaszynaTrasas()
        {
            return await _context.MaszynaTrasas.ToListAsync();
        }

        // GET: api/MaszynaTrasas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaszynaTrasa>> GetMaszynaTrasa(string id)
        {
            var maszynaTrasa = await _context.MaszynaTrasas.FindAsync(id);

            if (maszynaTrasa == null)
            {
                return NotFound();
            }

            return maszynaTrasa;
        }

        // PUT: api/MaszynaTrasas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaszynaTrasa(string id, MaszynaTrasa maszynaTrasa)
        {
            if (id != maszynaTrasa.NumerMaszyny)
            {
                return BadRequest();
            }

            _context.Entry(maszynaTrasa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaszynaTrasaExists(id))
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

        // POST: api/MaszynaTrasas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MaszynaTrasa>> PostMaszynaTrasa(MaszynaTrasa maszynaTrasa)
        {
            _context.MaszynaTrasas.Add(maszynaTrasa);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MaszynaTrasaExists(maszynaTrasa.NumerMaszyny))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMaszynaTrasa", new { id = maszynaTrasa.NumerMaszyny }, maszynaTrasa);
        }

        // DELETE: api/MaszynaTrasas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaszynaTrasa(string id)
        {
            var maszynaTrasa = await _context.MaszynaTrasas.FindAsync(id);
            if (maszynaTrasa == null)
            {
                return NotFound();
            }

            _context.MaszynaTrasas.Remove(maszynaTrasa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MaszynaTrasaExists(string id)
        {
            return _context.MaszynaTrasas.Any(e => e.NumerMaszyny == id);
        }
    }
}
