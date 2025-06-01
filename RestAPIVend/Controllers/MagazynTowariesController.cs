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
    public class MagazynTowariesController : ControllerBase
    {
        private readonly CompanyContext _context;
        private readonly IMapper _mapper;

        public MagazynTowariesController(CompanyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/MagazynTowaries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MagazynTowaryForView>>> GetMagazynTowaries()
        {
            if (_context.MagazynTowaries == null)
            {
                return NotFound();
            }

            var magazynTowary = await _context.MagazynTowaries
                .Include(p => p.IdtowaruNavigation)
                .Include(p => p.IdmagazynuNavigation)
                .Where(p => p.IsActive ?? false)
                .ToListAsync();

            var result = _mapper.Map<List<MagazynTowaryForView>>(magazynTowary);

            return Ok(result);
        }

        // GET: api/MagazynTowaries/5
        [HttpGet("{idMagazynu}/{idTowaru}")]
        public async Task<ActionResult<MagazynTowaryForView>> GetMagazynTowary(int idMagazynu, int idTowaru)
        {
            var magazynTowary = await _context.MagazynTowaries
                .Include(p => p.IdtowaruNavigation)
                .Include(p => p.IdmagazynuNavigation)
                .Where(p => (p.IsActive ?? false) &&
                            p.Idtowaru == idTowaru && 
                            p.Idmagazynu == idMagazynu)
                .FirstOrDefaultAsync();

            if (magazynTowary == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<MagazynTowaryForView>(magazynTowary);

            return Ok(result);
        }

        // PUT: api/MagazynTowaries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{idMagazynu}/{idTowaru}")]
        public async Task<IActionResult> PutMagazynTowary(int idMagazynu, int idTowaru, MagazynTowaryForView magazynTowaryForView)
        {
            var existing = await _context.MagazynTowaries
                .FirstOrDefaultAsync(p => p.Idmagazynu == idMagazynu && p.Idtowaru == idTowaru);
            if (existing == null) return NotFound();

            _mapper.Map(magazynTowaryForView, existing);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/MagazynTowaries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MagazynTowaryForView>> PostMagazynTowary(MagazynTowaryForView magazynTowaryForView)
        {
            var magazynTowary = _mapper.Map<MagazynTowary>(magazynTowaryForView);
            _context.MagazynTowaries.Add(magazynTowary);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<MagazynTowaryForView>(magazynTowary);

            return CreatedAtAction("GetMagazynTowary", new { idMagazynu = result.Idmagazynu, idTowaru = result.Idtowaru }, result);
        }

        // DELETE: api/MagazynTowaries/5
        [HttpDelete("{idMagazynu}/{idTowaru}")]
        public async Task<IActionResult> DeleteMagazynTowary(int idMagazynu, int idTowaru)
        {
            var magazynTowary = await _context.MagazynTowaries.FirstOrDefaultAsync(p => p.Idmagazynu == idMagazynu && p.Idtowaru == idTowaru);
            if (magazynTowary == null)
            {
                return NotFound();
            }

            magazynTowary.IsActive = false;
            _context.Entry(magazynTowary).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool MagazynTowaryExists(int idMagazynu, int idTowaru)
        {
            return _context.MagazynTowaries.Any(e => e.Idmagazynu == idMagazynu && e.Idtowaru == idTowaru);
        }
    }
}
