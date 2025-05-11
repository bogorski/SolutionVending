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
    public class WarsztatiesController : ControllerBase
    {
        private readonly CompanyContext _context;
        private readonly IMapper _mapper;
        public WarsztatiesController(CompanyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Warsztaties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WarsztatyForView>>> GetWarsztaties()
        {
            var warsztaty = await _context.Warsztaties.Where(d => d.IsActive ?? false).ToListAsync();

            var result = _mapper.Map<List<WarsztatyForView>>(warsztaty);

            return Ok(result);
        }

        // GET: api/Warsztaties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WarsztatyForView>> GetWarsztaty(int id)
        {
            var warsztaty = await _context.Warsztaties.FindAsync(id);

            if (warsztaty == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<WarsztatyForView>(warsztaty);

            return Ok(result);
        }

        // PUT: api/Warsztaties/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWarsztaty(int id, WarsztatyForView warsztatyForView)
        {
            var existing = await _context.Warsztaties.FindAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(warsztatyForView, existing);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Warsztaties
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Warsztaty>> PostWarsztaty(WarsztatyForView warsztatyForView)
        {
            var warsztaty = _mapper.Map<Warsztaty>(warsztatyForView);
            _context.Warsztaties.Add(warsztaty);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<WarsztatyForView>(warsztaty);

            return CreatedAtAction("GetWarsztaty", new { id = result.Idwarsztatu }, result);
        }

        // DELETE: api/Warsztaties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWarsztaty(int id)
        {
            var warsztaty = await _context.Warsztaties.FindAsync(id);
            if (warsztaty == null)
            {
                return NotFound();
            }

            warsztaty.IsActive = false;
            _context.Entry(warsztaty).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WarsztatyExists(int id)
        {
            return _context.Warsztaties.Any(e => e.Idwarsztatu == id);
        }
    }
}
