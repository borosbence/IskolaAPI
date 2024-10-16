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
    public class TanarokController : ControllerBase
    {
        private readonly iskolaContext _context;

        public TanarokController(iskolaContext context)
        {
            _context = context;
        }

        // GET: api/Tanarok
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tanarok>>> Gettanarok()
        {
            return await _context.tanarok.ToListAsync();
        }

        // GET: api/Tanarok/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tanarok>> Gettanarok(int id)
        {
            var tanarok = await _context.tanarok.FindAsync(id);

            if (tanarok == null)
            {
                return NotFound();
            }

            return tanarok;
        }

        // PUT: api/Tanarok/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttanarok(int id, tanarok tanarok)
        {
            if (id != tanarok.id)
            {
                return BadRequest();
            }

            _context.Entry(tanarok).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tanarokExists(id))
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

        // POST: api/Tanarok
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tanarok>> Posttanarok(tanarok tanarok)
        {
            _context.tanarok.Add(tanarok);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettanarok", new { id = tanarok.id }, tanarok);
        }

        // DELETE: api/Tanarok/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetanarok(int id)
        {
            var tanarok = await _context.tanarok.FindAsync(id);
            if (tanarok == null)
            {
                return NotFound();
            }

            _context.tanarok.Remove(tanarok);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tanarokExists(int id)
        {
            return _context.tanarok.Any(e => e.id == id);
        }
    }
}
