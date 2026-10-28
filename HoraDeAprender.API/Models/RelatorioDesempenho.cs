using System.ComponentModel.DataAnnotations;

namespace HoraDeAprender.API.Models
{
    public class RelatorioDesempenho
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int AlunoId { get; set; }
        [Required]
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        [Range(0, 10)]
        public double Nota { get; set; }
        public DateTime DataAvaliacao { get; set; } = DateTime.Now;
    }
}
