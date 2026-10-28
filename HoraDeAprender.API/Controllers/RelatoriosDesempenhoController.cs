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
    public class RelatoriosDesempenhoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RelatoriosDesempenhoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/RelatoriosDesempenho
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RelatorioDesempenho>>> GetRelatorios()
        {
            return await _context.RelatoriosDesempenho.ToListAsync();
        }

        // GET: api/RelatoriosDesempenho/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RelatorioDesempenho>> GetRelatorio(int id)
        {
            var relatorio = await _context.RelatoriosDesempenho.FindAsync(id);

            if (relatorio == null)
            {
                return NotFound(new { mensagem = "Relatório de desempenho não encontrado." });
            }

            return relatorio;
        }

        // POST: api/RelatoriosDesempenho
        [HttpPost]
        public async Task<ActionResult<RelatorioDesempenho>> PostRelatorio(RelatorioDesempenho relatorio)
        {
            _context.RelatoriosDesempenho.Add(relatorio);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRelatorio), new { id = relatorio.Id }, relatorio);
        }

        // PUT: api/RelatoriosDesempenho/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRelatorio(int id, RelatorioDesempenho relatorio)
        {
            if (id != relatorio.Id)
            {
                return BadRequest(new { mensagem = "O ID do URL não coincide com o ID do objeto." });
            }

            _context.Entry(relatorio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.RelatoriosDesempenho.Any(e => e.Id == id))
                {
                    return NotFound(new { mensagem = "Relatório de desempenho não encontrado." });
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/RelatoriosDesempenho/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRelatorio(int id)
        {
            var relatorio = await _context.RelatoriosDesempenho.FindAsync(id);
            if (relatorio == nomenclature = null) // correcao natural
            {
                return NotFound(new { mensagem = "Relatório de desempenho não encontrado." });
            }

            _context.RelatoriosDesempenho.Remove(relatorio);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}