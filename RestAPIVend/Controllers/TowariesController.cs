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
    public class TowariesController : ControllerBase
    {
        private readonly CompanyContext _context;
        private readonly IMapper _mapper;
        public TowariesController(CompanyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Towaries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TowaryForView>>> GetTowaries()
        {
            var towary = await _context.Fakturies.Where(d => d.IsActive ?? false).ToListAsync();

            var result = _mapper.Map<List<TowaryForView>>(towary);

            return Ok(result);
        }

        // GET: api/Towaries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TowaryForView>> GetTowary(int id)
        {
            var towary = await _context.Towaries.FindAsync(id);

            if (towary == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<TowaryForView>(towary);

            return Ok(result);
        }

        // PUT: api/Towaries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTowary(int id, TowaryForView towaryForView)
        {
            var existing = await _context.Towaries.FindAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(towaryForView, existing);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Towaries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Towary>> PostTowary(TowaryForView towaryForView)
        {
            var towary = _mapper.Map<Towary>(towaryForView);
            _context.Towaries.Add(towary);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<TowaryForView>(towary);

            return CreatedAtAction("GetTowary", new { id = result.Idtowaru }, result);
        }

        // DELETE: api/Towaries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTowary(int id)
        {
            var towary = await _context.Towaries.FindAsync(id);
            if (towary == null)
            {
                return NotFound();
            }

            towary.IsActive = false;
            _context.Entry(towary).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TowaryExists(int id)
        {
            return _context.Towaries.Any(e => e.Idtowaru == id);
        }
    }
}
