using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPIVend.ForView;
using RestAPIVend.Model;
using RestAPIVend.Model.Context;

namespace RestAPIVend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PojazdiesController : ControllerBase
    {
        private readonly CompanyContext _context;
        private readonly IMapper _mapper;

        public PojazdiesController(CompanyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Pojazdies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PojazdyForView>>> GetPojazdies()
        {
            if (_context.Pojazdies == null)
            {
                return NotFound();
            }

            var pojazdy = await _context.Pojazdies
                .Include(p => p.IdwarsztatuNavigation)
                .Where(p => p.IsActive ?? false)
                .ToListAsync();

            var result = _mapper.Map<List<PojazdyForView>>(pojazdy);

            return Ok(result);
        }

        // GET: api/Pojazdies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PojazdyForView>> GetPojazdy(int id)
        {
            var pojazdy = await _context.Pojazdies.Include(p => p.IdwarsztatuNavigation)
                .Where(p => p.IsActive ?? false).FirstOrDefaultAsync(p => p.Idpojazdu == id);

            if (pojazdy == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<PojazdyForView>(pojazdy);

            return Ok(result);
        }

        // PUT: api/Pojazdies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPojazdy(int id, PojazdyForView pojazdyForView)
        {
            var existing = await _context.Pojazdies.FindAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(pojazdyForView, existing);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Pojazdies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PojazdyForView>> PostPojazdy(PojazdyForView pojazdyForView)
        {
            var pojazdy = _mapper.Map<Pojazdy>(pojazdyForView);
            _context.Pojazdies.Add(pojazdy);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<PojazdyForView>(pojazdy);

            return CreatedAtAction("GetPojazdy", new { id = result.Idpojazdu }, result);
        }

        // DELETE: api/Pojazdies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePojazdy(int id)
        {
            var pojazdy = await _context.Pojazdies.FindAsync(id);
            if (pojazdy == null)
            {
                return NotFound();
            }

            pojazdy.IsActive = false;
            _context.Entry(pojazdy).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool PojazdyExists(int id)
        {
            return _context.Pojazdies.Any(e => e.Idpojazdu == id);
        }
    }
}
