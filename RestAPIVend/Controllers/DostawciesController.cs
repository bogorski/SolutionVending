using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPIVend.ForView;
using RestAPIVend.Model;
using RestAPIVend.Model.Context;

namespace RestAPIVend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DostawciesController : ControllerBase
    {
        private readonly CompanyContext _context;
        private readonly IMapper _mapper;

        public DostawciesController(CompanyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Dostawcies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DostawcyForView>>> GetDostawcies()
        {
            if (_context.Dostawcies == null)
            {
                return NotFound();
            }

            var dostawcy = await _context.Dostawcies.Where(d => d.IsActive ?? false).ToListAsync(); // null traktowany jako false

            var result = _mapper.Map<List<DostawcyForView>>(dostawcy);

            return Ok(result);
        }

        // GET: api/Dostawcies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DostawcyForView>> GetDostawcy(int id)
        {
            var dostawcy = await _context.Dostawcies.FindAsync(id);

            if (dostawcy == null)
            {
                return NotFound();
            }

            // return dostawcy;
            var result = _mapper.Map<DostawcyForView>(dostawcy);

            return Ok(result);
        }

        // PUT: api/Dostawcies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDostawcy(int id, DostawcyForView dostawcyForView)
        {
            if (id != dostawcyForView.Iddostawcy)
            {
                return BadRequest();
            }

            var dostawcy = _mapper.Map<Dostawcy>(dostawcyForView);

            _context.Entry(dostawcy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DostawcyExists(id))
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

        // POST: api/Dostawcies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dostawcy>> PostDostawcy(DostawcyForView dostawcyForView)
        {
            var dostawcy = _mapper.Map<Dostawcy>(dostawcyForView);
            _context.Dostawcies.Add(dostawcy);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<DostawcyForView>(dostawcy);

            return CreatedAtAction("GetDostawcy", new { id = dostawcy.Iddostawcy }, result);
        }

        // DELETE: api/Dostawcies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDostawcy(int id)
        {
            var dostawcy = await _context.Dostawcies.FindAsync(id);
            if (dostawcy == null)
            {
                return NotFound();
            }

            dostawcy.IsActive = false;
            _context.Entry(dostawcy).State = EntityState.Modified;
            // _context.Dostawcies.Remove(dostawcy);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool DostawcyExists(int id)
        {
            return _context.Dostawcies.Any(e => e.Iddostawcy == id);
        }
    }
}
