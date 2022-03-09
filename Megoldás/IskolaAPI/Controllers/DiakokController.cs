using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IskolaAPI.Models;

namespace IskolaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiakokController : ControllerBase
    {
        private readonly iskolaContext _context;

        public DiakokController(iskolaContext context)
        {
            _context = context;
        }

        // GET: api/Diakok
        [HttpGet]
        public async Task<ActionResult<IEnumerable<diakok>>> Getdiakok()
        {
            return await _context.diakok.ToListAsync();
        }

        // GET: api/Diakok/5
        [HttpGet("{id}")]
        public async Task<ActionResult<diakok>> Getdiakok(int id)
        {
            var diakok = await _context.diakok.FindAsync(id);

            if (diakok == null)
            {
                return NotFound();
            }

            return diakok;
        }

        // PUT: api/Diakok/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putdiakok(int id, diakok diakok)
        {
            if (id != diakok.id)
            {
                return BadRequest();
            }

            _context.Entry(diakok).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!diakokExists(id))
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

        // POST: api/Diakok
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<diakok>> Postdiakok(diakok diakok)
        {
            _context.diakok.Add(diakok);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getdiakok", new { id = diakok.id }, diakok);
        }

        // DELETE: api/Diakok/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletediakok(int id)
        {
            var diakok = await _context.diakok.FindAsync(id);
            if (diakok == null)
            {
                return NotFound();
            }

            _context.diakok.Remove(diakok);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool diakokExists(int id)
        {
            return _context.diakok.Any(e => e.id == id);
        }
    }
}
