using System.ComponentModel.DataAnnotations;

namespace HoraDeAprender.API.Models
{
    public class MuralAviso
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O título do aviso é obrigatório.")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "A mensagem é obrigatória.")]
        public string Mensagem { get; set; } = string.Empty;

        public string Autor { get; set; } = "Administrador";

        public DateTime DataPublicacao { get; set; } = DateTime.Now;
    }
}