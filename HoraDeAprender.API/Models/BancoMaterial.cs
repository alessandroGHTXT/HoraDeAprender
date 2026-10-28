using System.ComponentModel.DataAnnotations;

namespace HoraDeAprender.API.Models
{
    public class BancoMaterial
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        [Required]
        public string UrlLink { get; set; } = string.Empty;
        public string Categoria { get; set; } = "Geral";
        public DateTime DataAdmissao { get; set; } = DateTime.Now;
    }
}
