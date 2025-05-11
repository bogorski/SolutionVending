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
    public class TrasiesController : ControllerBase
    {
        private readonly CompanyContext _context;
        private readonly IMapper _mapper;
        public TrasiesController(CompanyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Trasies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrasyForView>>> GetTrasies()
        {
            var trasy = await _context.Trasies.Where(d => d.IsActive ?? false).ToListAsync();

            var result = _mapper.Map<List<TrasyForView>>(trasy);

            return Ok(result);
        }

        // GET: api/Trasies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrasyForView>> GetTrasy(int id)
        {
            var trasy = await _context.Trasies.FindAsync(id);

            if (trasy == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<TrasyForView>(trasy);

            return Ok(result);
        }

        // PUT: api/Trasies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrasy(int id, TrasyForView trasyForView)
        {
            var existing = await _context.Trasies.FindAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(trasyForView, existing);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Trasies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trasy>> PostTrasy(TrasyForView trasyForView)
        {
            var trasy = _mapper.Map<Trasy>(trasyForView);
            _context.Trasies.Add(trasy);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<TrasyForView>(trasy);

            return CreatedAtAction("GetTrasy", new { id = result.Idtrasy }, result);
        }

        // DELETE: api/Trasies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrasy(int id)
        {
            var trasy = await _context.Trasies.FindAsync(id);
            if (trasy == null)
            {
                return NotFound();
            }

            trasy.IsActive = false;
            _context.Entry(trasy).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrasyExists(int id)
        {
            return _context.Trasies.Any(e => e.Idtrasy == id);
        }
    }
}
