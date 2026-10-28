using System.ComponentModel.DataAnnotations;

namespace HoraDeAprender.API.Models
{
    public class Aluno
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
