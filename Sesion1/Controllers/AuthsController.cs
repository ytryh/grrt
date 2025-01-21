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
    public class AuthsController : ControllerBase
    {
        private readonly RContext _context;

        public AuthsController(RContext context)
        {
            _context = context;
        }

        // GET: api/Auths
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Auth>>> GetAuths()
        {
            return await _context.Auths.ToListAsync();
        }

        // GET: api/Auths/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Auth>> GetAuth(string id)
        {
            var auth = await _context.Auths.FindAsync(id);

            if (auth == null)
            {
                return NotFound();
            }

            return auth;
        }

        // PUT: api/Auths/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuth(string id, Auth auth)
        {
            if (id != auth.Name)
            {
                return BadRequest();
            }

            _context.Entry(auth).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthExists(id))
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

        // POST: api/Auths
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Auth>> PostAuth(Auth auth)
        {
            _context.Auths.Add(auth);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AuthExists(auth.Name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAuth", new { id = auth.Name }, auth);
        }

        // DELETE: api/Auths/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuth(string id)
        {
            var auth = await _context.Auths.FindAsync(id);
            if (auth == null)
            {
                return NotFound();
            }

            _context.Auths.Remove(auth);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuthExists(string id)
        {
            return _context.Auths.Any(e => e.Name == id);
        }
    }
}
