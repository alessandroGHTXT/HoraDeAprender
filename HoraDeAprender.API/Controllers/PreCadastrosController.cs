using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HoraDeAprender.API.Data;
using HoraDeAprender.API.Models;

namespace HoraDeAprender.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreCadastrosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PreCadastrosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreCadastro>>> GetPreCadastros()
        {
            return await _context.PreCadastros.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PreCadastro>> GetPreCadastro(int id)
        {
            var preCadastro = await _context.PreCadastros.FindAsync(id);
            if (preCadastro == null) return NotFound(new { mensagem = "Pré-cadastro não encontrado." });
            return preCadastro;
        }

        [HttpPost]
        public async Task<ActionResult<PreCadastro>> PostPreCadastro(PreCadastro preCadastro)
        {
            _context.PreCadastros.Add(preCadastro);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPreCadastro), new { id = preCadastro.Id }, preCadastro);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreCadastro(int id, PreCadastro preCadastro)
        {
            if (id != preCadastro.Id) return BadRequest();
            _context.Entry(preCadastro).State = EntityState.Modified;
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException) {
                if (!_context.PreCadastros.Any(e => e.Id == id)) return NotFound();
                else throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePreCadastro(int id)
        {
            var preCadastro = await _context.PreCadastros.FindAsync(id);
            if (preCadastro == null) return NotFound();
            _context.PreCadastros.Remove(preCadastro);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
