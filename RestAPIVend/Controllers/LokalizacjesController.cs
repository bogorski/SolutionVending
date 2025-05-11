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
    public class LokalizacjesController : ControllerBase
    {
        private readonly CompanyContext _context;
        private readonly IMapper _mapper;

        public LokalizacjesController(CompanyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Lokalizacjes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LokalizacjeForView>>> GetLokalizacjes()
        {
            var lokalizacje = await _context.Lokalizacjes.Where(d => d.IsActive ?? false).ToListAsync();

            var result = _mapper.Map<List<LokalizacjeForView>>(lokalizacje);

            return Ok(result);
        }

        // GET: api/Lokalizacjes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LokalizacjeForView>> GetLokalizacje(int id)
        {
            var lokalizacje = await _context.Lokalizacjes.FindAsync(id);

            if (lokalizacje == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<LokalizacjeForView>(lokalizacje);

            return Ok(result);
        }

        // PUT: api/Lokalizacjes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLokalizacje(int id, LokalizacjeForView lokalizacjeForView)
        {
            var existing = await _context.Lokalizacjes.FindAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(lokalizacjeForView, existing);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Lokalizacjes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LokalizacjeForView>> PostLokalizacje(LokalizacjeForView lokalizacjeForView)
        {
            var lokalizacje = _mapper.Map<Lokalizacje>(lokalizacjeForView);
            _context.Lokalizacjes.Add(lokalizacje);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<LokalizacjeForView>(lokalizacje);

            return CreatedAtAction("GetLokalizacje", new { id = result.Idlokalizacji }, result);
        }

        // DELETE: api/Lokalizacjes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLokalizacje(int id)
        {
            var lokalizacje = await _context.Lokalizacjes.FindAsync(id);
            if (lokalizacje == null)
            {
                return NotFound();
            }

            lokalizacje.IsActive = false;
            _context.Entry(lokalizacje).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LokalizacjeExists(int id)
        {
            return _context.Lokalizacjes.Any(e => e.Idlokalizacji == id);
        }
    }
}
