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
    public class VezetosegController : ControllerBase
    {
        private readonly iskolaContext _context;

        public VezetosegController(iskolaContext context)
        {
            _context = context;
        }

        // GET: api/Vezetoseg
        [HttpGet]
        public async Task<ActionResult<IEnumerable<vezetoseg>>> Getvezetoseg()
        {
            return await _context.vezetoseg.ToListAsync();
        }

        // GET: api/Vezetoseg/5
        [HttpGet("{id}")]
        public async Task<ActionResult<vezetoseg>> Getvezetoseg(int id)
        {
            var vezetoseg = await _context.vezetoseg.FindAsync(id);

            if (vezetoseg == null)
            {
                return NotFound();
            }

            return vezetoseg;
        }

        // PUT: api/Vezetoseg/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putvezetoseg(int id, vezetoseg vezetoseg)
        {
            if (id != vezetoseg.id)
            {
                return BadRequest();
            }

            _context.Entry(vezetoseg).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!vezetosegExists(id))
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

        // POST: api/Vezetoseg
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<vezetoseg>> Postvezetoseg(vezetoseg vezetoseg)
        {
            _context.vezetoseg.Add(vezetoseg);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getvezetoseg", new { id = vezetoseg.id }, vezetoseg);
        }

        // DELETE: api/Vezetoseg/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletevezetoseg(int id)
        {
            var vezetoseg = await _context.vezetoseg.FindAsync(id);
            if (vezetoseg == null)
            {
                return NotFound();
            }

            _context.vezetoseg.Remove(vezetoseg);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool vezetosegExists(int id)
        {
            return _context.vezetoseg.Any(e => e.id == id);
        }
    }
}
