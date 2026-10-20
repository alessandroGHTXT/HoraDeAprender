 HEAD
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using HoraDeAprender.API.Data;
using HoraDeAprender.API.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace HoraDeAprender.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public UsuariosController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // POST: api/usuarios/registrar
        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] RegisterDto dto)
        {
            if (await _context.Usuarios.AnyAsync(u => u.Email == dto.Email))
            {
                return BadRequest(new { mensagem = "Este e-mail já está em uso." });
            }

            using var sha256 = SHA256.Create();
            var senhaBytes = Encoding.UTF8.GetBytes(dto.Senha);
            var hashBytes = sha256.ComputeHash(senhaBytes);
            var senhaHash = Convert.ToBase64String(hashBytes);

            var novoUsuario = new Usuario
            {
                Email = dto.Email,
                SenhaHash = senhaHash,
                Perfil = string.IsNullOrWhiteSpace(dto.Perfil) ? "Aluno" : dto.Perfil
            };

            _context.Usuarios.Add(novoUsuario);
            await _context.SaveChangesAsync();

            return Ok(new { mensagem = "Conta criada com sucesso!", id = novoUsuario.Id, email = novoUsuario.Email });
        }

        // POST: api/usuarios/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            // 1. Procurar o utilizador pelo e-mail
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (usuario == null)
            {
                return Unauthorized(new { mensagem = "E-mail ou palavra-passe incorretos." });
            }

            // 2. Encriptar a palavra-passe enviada e comparar com o hash guardado
            using var sha256 = SHA256.Create();
            var senhaBytes = Encoding.UTF8.GetBytes(dto.Senha);
            var hashBytes = sha256.ComputeHash(senhaBytes);
            var senhaHashDigitada = Convert.ToBase64String(hashBytes);

            if (usuario.SenhaHash != senhaHashDigitada)
            {
                return Unauthorized(new { mensagem = "E-mail ou palavra-passe incorretos." });
            }

            // 3. Gerar o Token JWT
            var token = GerarTokenJwt(usuario);

            return Ok(new
            {
                mensagem = "Login efetuado com sucesso!",
                token = token,
                usuario = new
                {
                    id = usuario.Id,
                    email = usuario.Email,
                    perfil = usuario.Perfil
                }
            });
        }

        private string GerarTokenJwt(Usuario usuario)
        {
            var keyBytes = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!);
            var key = new SymmetricSecurityKey(keyBytes);
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Role, usuario.Perfil)
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(8), // Token válido por 8 horas
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
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
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario([FromBody] Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuarios), new { id = usuario.Id }, usuario);
        }
    }

}