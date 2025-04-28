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
    public class ZamowienieTowariesController : ControllerBase
    {
        private readonly CompanyContext _context;

        public ZamowienieTowariesController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/ZamowienieTowaries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ZamowienieTowary>>> GetZamowienieTowaries()
        {
            return await _context.ZamowienieTowaries.ToListAsync();
        }

        // GET: api/ZamowienieTowaries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ZamowienieTowary>> GetZamowienieTowary(int id)
        {
            var zamowienieTowary = await _context.ZamowienieTowaries.FindAsync(id);

            if (zamowienieTowary == null)
            {
                return NotFound();
            }

            return zamowienieTowary;
        }

        // PUT: api/ZamowienieTowaries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZamowienieTowary(int id, ZamowienieTowary zamowienieTowary)
        {
            if (id != zamowienieTowary.Idzamowienia)
            {
                return BadRequest();
            }

            _context.Entry(zamowienieTowary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZamowienieTowaryExists(id))
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

        // POST: api/ZamowienieTowaries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ZamowienieTowary>> PostZamowienieTowary(ZamowienieTowary zamowienieTowary)
        {
            _context.ZamowienieTowaries.Add(zamowienieTowary);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ZamowienieTowaryExists(zamowienieTowary.Idzamowienia))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetZamowienieTowary", new { id = zamowienieTowary.Idzamowienia }, zamowienieTowary);
        }

        // DELETE: api/ZamowienieTowaries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZamowienieTowary(int id)
        {
            var zamowienieTowary = await _context.ZamowienieTowaries.FindAsync(id);
            if (zamowienieTowary == null)
            {
                return NotFound();
            }

            _context.ZamowienieTowaries.Remove(zamowienieTowary);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ZamowienieTowaryExists(int id)
        {
            return _context.ZamowienieTowaries.Any(e => e.Idzamowienia == id);
        }
    }
}
