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
    public class StanowiskaPraciesController : ControllerBase
    {
        private readonly CompanyContext _context;
        private readonly IMapper _mapper;

        public StanowiskaPraciesController(CompanyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/StanowiskaPracies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StanowiskaPracyForView>>> GetStanowiskaPracies()
        {
            var stanowiskaPracy = await _context.StanowiskaPracies.Where(d => d.IsActive ?? false).ToListAsync();

            var result = _mapper.Map<List<StanowiskaPracyForView>>(stanowiskaPracy);

            return Ok(result);
        }

        // GET: api/StanowiskaPracies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StanowiskaPracyForView>> GetStanowiskaPracy(int id)
        {
            var stanowiskaPracy = await _context.StanowiskaPracies.FindAsync(id);

            if (stanowiskaPracy == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<StanowiskaPracyForView>(stanowiskaPracy);

            return Ok(result);
        }

        // PUT: api/StanowiskaPracies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStanowiskaPracy(int id, StanowiskaPracyForView stanowiskaPracyForView)
        {
            var existing = await _context.StanowiskaPracies.FindAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(stanowiskaPracyForView, existing);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/StanowiskaPracies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StanowiskaPracy>> PostStanowiskaPracy(StanowiskaPracyForView stanowiskaPracyForView)
        {
            var stanowiskaPracy = _mapper.Map<Faktury>(stanowiskaPracyForView);
            _context.Fakturies.Add(stanowiskaPracy);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<StanowiskaPracyForView>(stanowiskaPracy);

            return CreatedAtAction("GetStanowiskaPracy", new { id = result.IdstanowiskaPracy }, result);
        }

        // DELETE: api/StanowiskaPracies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStanowiskaPracy(int id)
        {
            var stanowiskaPracy = await _context.StanowiskaPracies.FindAsync(id);
            if (stanowiskaPracy == null)
            {
                return NotFound();
            }

            stanowiskaPracy.IsActive = false;
            _context.Entry(stanowiskaPracy).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StanowiskaPracyExists(int id)
        {
            return _context.StanowiskaPracies.Any(e => e.IdstanowiskaPracy == id);
        }
    }
}
