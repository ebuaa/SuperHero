using Microsoft.AspNetCore.Mvc;
using hero_csharp.Models;
using hero_csharp.Data;
using Microsoft.EntityFrameworkCore;

namespace hero_csharp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuperPowersController : ControllerBase
    {
        private readonly DataContext _context;

        public SuperPowersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SuperPower>>> GetSuperPowers()
        {
            return Ok(await _context.SuperPowers.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperPower>> GetSuperPower(int id)
        {
            var superPower = await _context.SuperPowers.FindAsync(id);
            if (superPower == null)
            {
                return NotFound();
            }
            return Ok(superPower);
        }

        [HttpPost]
        public async Task<ActionResult<SuperPower>> PostSuperPower(SuperPower superPower)
        {
            _context.SuperPowers.Add(superPower);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSuperPower), new { id = superPower.Id }, superPower);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuperPower(int id, SuperPower superPower)
        {
            if (id != superPower.Id)
            {
                return BadRequest();
            }

            _context.Entry(superPower).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuperPower(int id)
        {
            var superPower = await _context.SuperPowers.FindAsync(id);
            if (superPower == null)
            {
                return NotFound();
            }

            _context.SuperPowers.Remove(superPower);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}