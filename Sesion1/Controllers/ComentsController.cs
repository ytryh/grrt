using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sesion1.DataBase;

namespace Sesion1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentsController : ControllerBase
    {
        private readonly RContext _context;

        public ComentsController(RContext context)
        {
            _context = context;
        }

        // GET: api/Coments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coment>>> GetComents()
        {
            return await _context.Coments.ToListAsync();
        }

        // GET: api/Coments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coment>> GetComent(int id)
        {
            var coment = await _context.Coments.FindAsync(id);

            if (coment == null)
            {
                return NotFound();
            }

            return coment;
        }

        // PUT: api/Coments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComent(int id, Coment coment)
        {
            if (id != coment.Id)
            {
                return BadRequest();
            }

            _context.Entry(coment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComentExists(id))
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

        // POST: api/Coments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Coment>> PostComent(Coment coment)
        {
            _context.Coments.Add(coment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComent", new { id = coment.Id }, coment);
        }

        // DELETE: api/Coments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComent(int id)
        {
            var coment = await _context.Coments.FindAsync(id);
            if (coment == null)
            {
                return NotFound();
            }

            _context.Coments.Remove(coment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComentExists(int id)
        {
            return _context.Coments.Any(e => e.Id == id);
        }
    }
}
