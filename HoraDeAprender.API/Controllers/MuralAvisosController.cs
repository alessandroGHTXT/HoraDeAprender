using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HoraDeAprender.API.Data;
using HoraDeAprender.API.Models;

namespace HoraDeAprender.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize] // Descomenta se quiseres exigir token JWT para gerir o mural
    public class MuralAvisosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MuralAvisosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/MuralAvisos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MuralAviso>>> GetMuralAvisos()
        {
            return await _context.MuralAvisos.OrderByDescending(a => a.DataPublicacao).ToListAsync();
        }

        // GET: api/MuralAvisos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MuralAviso>> GetMuralAviso(int id)
        {
            var aviso = await _context.MuralAvisos.FindAsync(id);

            if (aviso == null)
            {
                return NotFound(new { mensagem = "Aviso não encontrado." });
            }

            return aviso;
        }

        // POST: api/MuralAvisos
        [HttpPost]
        public async Task<ActionResult<MuralAviso>> PostMuralAviso(MuralAviso muralAviso)
        {
            _context.MuralAvisos.Add(muralAviso);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMuralAviso), new { id = muralAviso.Id }, muralAviso);
        }

        // DELETE: api/MuralAvisos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMuralAviso(int id)
        {
            var aviso = await _context.MuralAvisos.FindAsync(id);
            if (aviso == null)
            {
                return NotFound(new { mensagem = "Aviso não encontrado." });
            }

            _context.MuralAvisos.Remove(aviso);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}