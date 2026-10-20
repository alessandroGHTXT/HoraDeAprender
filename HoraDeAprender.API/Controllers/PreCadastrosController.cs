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

        // GET: api/precadastros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreCadastro>>> GetPreCadastros()
        {
            return await _context.PreCadastros.ToListAsync();
        }

        // POST: api/precadastros
        [HttpPost]
        public async Task<ActionResult<PreCadastro>> PostPreCadastro([FromBody] PreCadastro preCadastro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PreCadastros.Add(preCadastro);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPreCadastros), new { id = preCadastro.Id }, preCadastro);
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
    public class PreCadastrosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PreCadastrosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/precadastros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreCadastro>>> GetPreCadastros()
        {
            return await _context.PreCadastros.ToListAsync();
        }

        // POST: api/precadastros
        [HttpPost]
        public async Task<ActionResult<PreCadastro>> PostPreCadastro([FromBody] PreCadastro preCadastro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PreCadastros.Add(preCadastro);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPreCadastros), new { id = preCadastro.Id }, preCadastro);
        }
    }
}