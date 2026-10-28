using System.ComponentModel.DataAnnotations;

namespace HoraDeAprender.API.Models
{
    public class PreCadastro
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NomeAluno { get; set; } = string.Empty;
        [Required]
        public string Serie { get; set; } = string.Empty;
        [Required]
        public string NomeResponsavel { get; set; } = string.Empty;
        [Required]
        public string EmailResponsavel { get; set; } = string.Empty;
        public string TelefoneResponsavel { get; set; } = string.Empty;
        public string Status { get; set; } = "Pendente";
        public DateTime DataSolicitacao { get; set; } = DateTime.Now;
    }
}
