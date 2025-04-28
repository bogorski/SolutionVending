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
    public class ZamowieniaZewnetrzneController : ControllerBase
    {
        private readonly CompanyContext _context;

        public ZamowieniaZewnetrzneController(CompanyContext context)
        {
            _context = context;
        }

        // GET: api/ZamowieniaZewnetrzne
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ZamowieniaZewnetrzne>>> GetZamowieniaZewnetrznes()
        {
            return await _context.ZamowieniaZewnetrznes.ToListAsync();
        }

        // GET: api/ZamowieniaZewnetrzne/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ZamowieniaZewnetrzne>> GetZamowieniaZewnetrzne(int id)
        {
            var zamowieniaZewnetrzne = await _context.ZamowieniaZewnetrznes.FindAsync(id);

            if (zamowieniaZewnetrzne == null)
            {
                return NotFound();
            }

            return zamowieniaZewnetrzne;
        }

        // PUT: api/ZamowieniaZewnetrzne/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZamowieniaZewnetrzne(int id, ZamowieniaZewnetrzne zamowieniaZewnetrzne)
        {
            if (id != zamowieniaZewnetrzne.IdzamowienieZewnetrzne)
            {
                return BadRequest();
            }

            _context.Entry(zamowieniaZewnetrzne).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZamowieniaZewnetrzneExists(id))
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

        // POST: api/ZamowieniaZewnetrzne
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ZamowieniaZewnetrzne>> PostZamowieniaZewnetrzne(ZamowieniaZewnetrzne zamowieniaZewnetrzne)
        {
            _context.ZamowieniaZewnetrznes.Add(zamowieniaZewnetrzne);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetZamowieniaZewnetrzne", new { id = zamowieniaZewnetrzne.IdzamowienieZewnetrzne }, zamowieniaZewnetrzne);
        }

        // DELETE: api/ZamowieniaZewnetrzne/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZamowieniaZewnetrzne(int id)
        {
            var zamowieniaZewnetrzne = await _context.ZamowieniaZewnetrznes.FindAsync(id);
            if (zamowieniaZewnetrzne == null)
            {
                return NotFound();
            }

            _context.ZamowieniaZewnetrznes.Remove(zamowieniaZewnetrzne);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ZamowieniaZewnetrzneExists(int id)
        {
            return _context.ZamowieniaZewnetrznes.Any(e => e.IdzamowienieZewnetrzne == id);
        }
    }
}
