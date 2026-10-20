<<<<<<< HEAD
using Microsoft.EntityFrameworkCore;
using HoraDeAprender.API.Models;

namespace HoraDeAprender.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<PreCadastro> PreCadastros { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<RelatorioDesempenho> RelatoriosDesempenho { get; set; }
        public DbSet<MuralAviso> MuralAvisos { get; set; }
        public DbSet<BancoMaterial> BancoMateriais { get; set; }
        public DbSet<FocoMes> FocoMeses { get; set; }
    }
=======
using Microsoft.EntityFrameworkCore;
using HoraDeAprender.API.Models;

namespace HoraDeAprender.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<PreCadastro> PreCadastros { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<RelatorioDesempenho> RelatoriosDesempenho { get; set; }
        public DbSet<MuralAviso> MuralAvisos { get; set; }
        public DbSet<BancoMaterial> BancoMateriais { get; set; }
        public DbSet<FocoMes> FocoMeses { get; set; }
    }
>>>>>>> de2ee822d0f036437a66da93cefb029b32823161
}