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

        [HttpPost]
        public async Task<ActionResult<RelatorioDesempenho>> PostRelatorio([FromBody] RelatorioDesempenho relatorio)
        {
            _context.RelatoriosDesempenho.Add(relatorio);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRelatorios), new { id = relatorio.Id }, relatorio);
        }
    }
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

        [HttpPost]
        public async Task<ActionResult<RelatorioDesempenho>> PostRelatorio([FromBody] RelatorioDesempenho relatorio)
        {
            _context.RelatoriosDesempenho.Add(relatorio);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRelatorios), new { id = relatorio.Id }, relatorio);
        }
    }
}