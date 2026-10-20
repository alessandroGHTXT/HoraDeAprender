using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HoraDeAprender.API.Data;
using HoraDeAprender.API.Models;

namespace HoraDeAprender.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuralAvisosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MuralAvisosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MuralAviso>>> GetMuralAvisos()
        {
            return await _context.MuralAvisos.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<MuralAviso>> PostMuralAviso([FromBody] MuralAviso aviso)
        {
            _context.MuralAvisos.Add(aviso);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMuralAvisos), new { id = aviso.Id }, aviso);
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
    public class MuralAvisosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MuralAvisosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MuralAviso>>> GetMuralAvisos()
        {
            return await _context.MuralAvisos.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<MuralAviso>> PostMuralAviso([FromBody] MuralAviso aviso)
        {
            _context.MuralAvisos.Add(aviso);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMuralAvisos), new { id = aviso.Id }, aviso);
        }
    }
}