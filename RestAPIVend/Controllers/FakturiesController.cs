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
    public class FakturiesController : ControllerBase
    {
        private readonly CompanyContext _context;
        private readonly IMapper _mapper;

        public FakturiesController(CompanyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Fakturies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FakturyForView>>> GetFakturies()
        {
            if (_context.Fakturies == null)
            {
                return NotFound();
            }

            var faktury = await _context.Fakturies.Where(d => d.IsActive ?? false).ToListAsync();

            var result = _mapper.Map<List<FakturyForView>>(faktury);

            return Ok(result);
        }

        // GET: api/Fakturies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FakturyForView>> GetFaktury(int id)
        {
            var faktury = await _context.Fakturies.FindAsync(id);

            if (faktury == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<FakturyForView>(faktury);

            return Ok(result);
        }

        // PUT: api/Fakturies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFaktury(int id, FakturyForView fakturyForView)
        {
            var existing = await _context.Fakturies.FindAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(fakturyForView, existing);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Fakturies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FakturyForView>> PostFaktury(FakturyForView fakturyForView)
        {
            var faktury = _mapper.Map<Faktury>(fakturyForView);
            _context.Fakturies.Add(faktury);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<FakturyForView>(faktury);

            return CreatedAtAction("GetFaktury", new { id = result.Idfaktury }, result);
        }

        // DELETE: api/Fakturies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFaktury(int id)
        {
            var faktury = await _context.Fakturies.FindAsync(id);
            if (faktury == null)
            {
                return NotFound();
            }

            faktury.IsActive = false;
            _context.Entry(faktury).State = EntityState.Modified;
            //_context.Fakturies.Remove(faktury);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FakturyExists(int id)
        {
            return _context.Fakturies.Any(e => e.Idfaktury == id);
        }
    }
}
