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
    public class MaszyniesController : ControllerBase
    {
        private readonly CompanyContext _context;
        private readonly IMapper _mapper;


        public MaszyniesController(CompanyContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Maszynies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaszynyForView>>> GetMaszynies()
        {
            if (_context.Maszynies == null)
            {
                return NotFound();
            }

            var maszyny = await _context.Maszynies
                .Include(p => p.IdtypMaszynyNavigation)
                .Where(p => p.IsActive ?? false)
                .ToListAsync();

            var result = _mapper.Map<List<MaszynyForView>>(maszyny);

            return Ok(result);
        }

        // GET: api/Maszynies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaszynyForView>> GetMaszyny(int id)
        {
            var maszyny = await _context.Maszynies.Include(p => p.IdtypMaszynyNavigation)
                .Where(p => p.IsActive ?? false).FirstOrDefaultAsync(p => p.Id == id);

            if (maszyny == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<MaszynyForView>(maszyny);

            return Ok(result);
        }

        // PUT: api/Maszynies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaszyny(int id, MaszynyForView maszynyForView)
        {
            var existing = await _context.Maszynies.FindAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(maszynyForView, existing);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Maszynies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MaszynyForView>> PostMaszyny(MaszynyForView maszynyForView)
        {
            var maszyny = _mapper.Map<Maszyny>(maszynyForView);
            _context.Maszynies.Add(maszyny);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<MaszynyForView>(maszyny);

            return CreatedAtAction("GetMaszyny", new { id = result.Id }, result);
        }

        // DELETE: api/Maszynies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaszyny(int id)
        {
            var maszyny = await _context.Maszynies.FindAsync(id);
            if (maszyny == null)
            {
                return NotFound();
            }

            maszyny.IsActive = false;
            _context.Entry(maszyny).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool MaszynyExists(int id)
        {
            return _context.Maszynies.Any(m => m.Id == id);
        }
    }
}
