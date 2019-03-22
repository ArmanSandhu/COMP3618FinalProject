using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IMDbDomain.Models;

namespace IMDbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitlebasicsController : ControllerBase
    {
        private readonly IMDbContext _context;

        public TitlebasicsController(IMDbContext context)
        {
            _context = context;
        }

        // GET: api/Titlebasics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Titlebasics>>> GetTitlebasics()
        {
            return await _context.Titlebasics.ToListAsync();
        }

        // GET: api/Titlebasics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Titlebasics>> GetTitlebasics(string id)
        {
            var titlebasics = await _context.Titlebasics.FindAsync(id);

            if (titlebasics == null)
            {
                return NotFound();
            }

            return titlebasics;
        }

        // PUT: api/Titlebasics/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTitlebasics(string id, Titlebasics titlebasics)
        {
            if (id != titlebasics.Tconst)
            {
                return BadRequest();
            }

            _context.Entry(titlebasics).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TitlebasicsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Titlebasics
        [HttpPost]
        public async Task<ActionResult<Titlebasics>> PostTitlebasics(Titlebasics titlebasics)
        {
            _context.Titlebasics.Add(titlebasics);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TitlebasicsExists(titlebasics.Tconst))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTitlebasics", new { id = titlebasics.Tconst }, titlebasics);
        }

        // DELETE: api/Titlebasics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Titlebasics>> DeleteTitlebasics(string id)
        {
            var titlebasics = await _context.Titlebasics.FindAsync(id);
            if (titlebasics == null)
            {
                return NotFound();
            }

            _context.Titlebasics.Remove(titlebasics);
            await _context.SaveChangesAsync();

            return titlebasics;
        }

        private bool TitlebasicsExists(string id)
        {
            return _context.Titlebasics.Any(e => e.Tconst == id);
        }
    }
}
