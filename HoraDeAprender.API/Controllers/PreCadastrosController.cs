using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HoraDeAprender.API.Data;
using HoraDeAprender.API.Models;

namespace HoraDeAprender.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize] // Descomenta se quiseres exigir token JWT
    public class PreCadastrosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PreCadastrosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PreCadastros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreCadastro>>> GetPreCadastros()
        {
            return await _context.PreCadastros.ToListAsync();
        }

        // GET: api/PreCadastros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PreCadastro>> GetPreCadastro(int id)
        {
            var preCadastro = await _context.PreCadastros.FindAsync(id);

            if (preCadastro == null)
            {
                return NotFound(new { mensagem = "Pré-cadastro não encontrado." });
            }

            return preCadastro;
        }

        // POST: api/PreCadastros
        [HttpPost]
        public async Task<ActionResult<PreCadastro>> PostPreCadastro(PreCadastro preCadastro)
        {
            _context.PreCadastros.Add(preCadastro);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPreCadastro), new { id = preCadastro.Id }, preCadastro);
        }

        // PUT: api/PreCadastros/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreCadastro(int id, PreCadastro preCadastro)
        {
            if (id != preCadastro.Id)
            {
                return BadRequest(new { mensagem = "O ID do URL não coincide com o ID do objeto." });
            }

            _context.Entry(preCadastro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.PreCadastros.Any(e => e.Id == id))
                {
                    return NotFound(new { mensagem = "Pré-cadastro não encontrado." });
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/PreCadastros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePreCadastro(int id)
        {
            var preCadastro = await _context.PreCadastros.FindAsync(id);
            if (preCadastro == null)
            {
                return NotFound(new { mensagem = "Pré-cadastro não encontrado." });
            }

            _context.PreCadastros.Remove(preCadastro);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}