<<<<<<< HEAD
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HoraDeAprender.API.Data;
using HoraDeAprender.API.Models;

namespace HoraDeAprender.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancoMateriaisController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BancoMateriaisController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BancoMaterial>>> GetBancoMateriais()
        {
            return await _context.BancoMateriais.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<BancoMaterial>> PostBancoMaterial([FromBody] BancoMaterial material)
        {
            _context.BancoMateriais.Add(material);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBancoMateriais), new { id = material.Id }, material);
        }
    }
=======
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HoraDeAprender.API.Data;
using HoraDeAprender.API.Models;

namespace HoraDeAprender.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancoMateriaisController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BancoMateriaisController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BancoMaterial>>> GetBancoMateriais()
        {
            return await _context.BancoMateriais.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<BancoMaterial>> PostBancoMaterial([FromBody] BancoMaterial material)
        {
            _context.BancoMateriais.Add(material);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBancoMateriais), new { id = material.Id }, material);
        }
    }
>>>>>>> de2ee822d0f036437a66da93cefb029b32823161
}