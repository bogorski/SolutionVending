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
    public class MagazyniesController : ControllerBase
    {
        private readonly CompanyContext _context;
        private readonly IMapper _mapper;

        public MagazyniesController(CompanyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Magazynies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MagazynyForView>>> GetMagazynies()
        {
            var magazyny = await _context.Magazynies.Where(d => d.IsActive ?? false).ToListAsync();

            var result = _mapper.Map<List<MagazynyForView>>(magazyny);

            return Ok(result);
        }

        // GET: api/Magazynies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MagazynyForView>> GetMagazyny(int id)
        {
            var magazyny = await _context.Magazynies.FindAsync(id);

            if (magazyny == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<MagazynyForView>(magazyny);

            return Ok(result);
        }

        // PUT: api/Magazynies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMagazyny(int id, MagazynyForView magazynyForView)
        {
            var existing = await _context.Magazynies.FindAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(magazynyForView, existing);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Magazynies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Magazyny>> PostMagazyny(MagazynyForView magazynyForView)
        {
            var magazyny = _mapper.Map<Magazyny>(magazynyForView);
            _context.Magazynies.Add(magazyny);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<MagazynyForView>(magazyny);

            return CreatedAtAction("GetMagazyny", new { id = result.Idmagazynu }, result);
        }

        // DELETE: api/Magazynies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMagazyny(int id)
        {
            var magazyny = await _context.Magazynies.FindAsync(id);
            if (magazyny == null)
            {
                return NotFound();
            }

            magazyny.IsActive = false;
            _context.Entry(magazyny).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MagazynyExists(int id)
        {
            return _context.Magazynies.Any(e => e.Idmagazynu == id);
        }
    }
}
