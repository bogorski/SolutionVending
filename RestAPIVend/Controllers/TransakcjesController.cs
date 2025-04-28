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
    public class TransakcjesController : ControllerBase
    {
        private readonly CompanyContext _context;

        public TransakcjesController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/Transakcjes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transakcje>>> GetTransakcjes()
        {
            return await _context.Transakcjes.ToListAsync();
        }

        // GET: api/Transakcjes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transakcje>> GetTransakcje(int id)
        {
            var transakcje = await _context.Transakcjes.FindAsync(id);

            if (transakcje == null)
            {
                return NotFound();
            }

            return transakcje;
        }

        // PUT: api/Transakcjes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransakcje(int id, Transakcje transakcje)
        {
            if (id != transakcje.Idtransakcji)
            {
                return BadRequest();
            }

            _context.Entry(transakcje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransakcjeExists(id))
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

        // POST: api/Transakcjes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Transakcje>> PostTransakcje(Transakcje transakcje)
        {
            _context.Transakcjes.Add(transakcje);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransakcje", new { id = transakcje.Idtransakcji }, transakcje);
        }

        // DELETE: api/Transakcjes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransakcje(int id)
        {
            var transakcje = await _context.Transakcjes.FindAsync(id);
            if (transakcje == null)
            {
                return NotFound();
            }

            _context.Transakcjes.Remove(transakcje);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransakcjeExists(int id)
        {
            return _context.Transakcjes.Any(e => e.Idtransakcji == id);
        }
    }
}
