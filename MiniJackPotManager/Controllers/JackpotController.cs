using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniJackPotManager.Data;
using MiniJackPotManager.Models;

namespace MiniJackPotManager.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class JackpotsController : ControllerBase
    {
        private readonly AppDbContent _context;

        public JackpotsController(AppDbContent context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jackpot>>> GetJackpots()
        {
            return await _context.Jackpots.ToListAsync();
        }

        [HttpPost("{id}/contribute")]
        public async Task<IActionResult> Contribute(int id, [FromBody] Contribution con)
        {
            var jackpot = await _context.Jackpots.FindAsync(id);

            if (jackpot == null)
                return NotFound();

            jackpot.CurrentValue += con.Amount;

            if (jackpot.CurrentValue >= jackpot.HitThreshold)
            {
                Console.WriteLine($"Jackpot {id} hit threshold. Resetting to SeedValue.");
                jackpot.CurrentValue = jackpot.SeedValue;
            }

            await _context.SaveChangesAsync();

            return Ok(jackpot);
        }
    }

    public class Contribution
    {
        public decimal Amount { get; set; }
    }
}

