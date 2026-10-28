using System.ComponentModel.DataAnnotations;

namespace HoraDeAprender.API.Models
{
    public class FocoMes
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Mes { get; set; } = string.Empty;
        [Required]
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public bool Ativo { get; set; } = true;
    }
}
