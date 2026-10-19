using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HoraDeAprender.API.Data;
using HoraDeAprender.API.Models;

namespace HoraDeAprender.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FocoMesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FocoMesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FocoMes>>> GetFocoMes()
        {
            return await _context.FocoMeses.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<FocoMes>> PostFocoMes([FromBody] FocoMes foco)
        {
            _context.FocoMeses.Add(foco);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFocoMes), new { id = foco.Id }, foco);
        }
    }
}