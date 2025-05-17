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
    public class PracowniciesController : ControllerBase
    {
        private readonly CompanyContext _context;
        private readonly IMapper _mapper;

        public PracowniciesController(CompanyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Pracownicies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PracownicyForView>>> GetPracownicies()
        {
            if (_context.Pracownicies == null)
            {
                return NotFound();
            }

            var pracownicy = await _context.Pracownicies
                .Include(p => p.IdstanowiskaPracyNavigation)
                .Include(p => p.IdpojazduNavigation)
                .Include(p => p.IdtrasyNavigation)
                .Where(p => p.IsActive ?? false)
                .ToListAsync();

            var result = _mapper.Map<List<PracownicyForView>>(pracownicy);

            return Ok(result);
        }

        // GET: api/Pracownicies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PracownicyForView>> GetPracownicy(int id)
        {
            var pracownicy = await _context.Pracownicies
                .Include(p => p.IdstanowiskaPracyNavigation)
                .Include(p => p.IdpojazduNavigation)
                .Include(p => p.IdtrasyNavigation)
                .Where(p => p.IsActive ?? false).FirstOrDefaultAsync(p => p.Idpracownika == id);

            if (pracownicy == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<PracownicyForView>(pracownicy);

            return Ok(result);
        }

        // PUT: api/Pracownicies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPracownicy(int id, PracownicyForView pracownicyForView)
        {
            var existing = await _context.Pracownicies.FindAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(pracownicyForView, existing);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Pracownicies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PracownicyForView>> PostPracownicy(PracownicyForView pracownicyForView)
        {
            var pracownicy = _mapper.Map<Pracownicy>(pracownicyForView);
            _context.Pracownicies.Add(pracownicy);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<PracownicyForView>(pracownicy);

            return CreatedAtAction("GetPracownicy", new { id = result.Idpracownika }, result);
        }

        // DELETE: api/Pracownicies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePracownicy(int id)
        {
            var pracownicy = await _context.Pracownicies.FindAsync(id);
            if (pracownicy == null)
            {
                return NotFound();
            }

            pracownicy.IsActive = false;
            _context.Entry(pracownicy).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PracownicyExists(int id)
        {
            return _context.Pracownicies.Any(e => e.Idpracownika == id);
        }
    }
}
