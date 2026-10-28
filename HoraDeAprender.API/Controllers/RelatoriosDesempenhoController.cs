using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HoraDeAprender.API.Data;
using HoraDeAprender.API.Models;

namespace HoraDeAprender.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelatoriosDesempenhoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RelatoriosDesempenhoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RelatorioDesempenho>>> GetRelatorios()
        {
            return await _context.RelatoriosDesempenho.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RelatorioDesempenho>> GetRelatorio(int id)
        {
            var relatorio = await _context.RelatoriosDesempenho.FindAsync(id);
            if (relatorio == null) return NotFound(new { mensagem = "Relatório não encontrado." });
            return relatorio;
        }

        [HttpPost]
        public async Task<ActionResult<RelatorioDesempenho>> PostRelatorio(RelatorioDesempenho relatorio)
        {
            _context.RelatoriosDesempenho.Add(relatorio);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRelatorio), new { id = relatorio.Id }, relatorio);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRelatorio(int id, RelatorioDesempenho relatorio)
        {
            if (id != relatorio.Id) return BadRequest();
            _context.Entry(relatorio).State = EntityState.Modified;
            try { await _context.SaveChangesAsync(); }
            catch (DbUpdateConcurrencyException) {
                if (!_context.RelatoriosDesempenho.Any(e => e.Id == id)) return NotFound();
                else throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRelatorio(int id)
        {
            var relatorio = await _context.RelatoriosDesempenho.FindAsync(id);
            if (relatorio == null) return NotFound();
            _context.RelatoriosDesempenho.Remove(relatorio);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
