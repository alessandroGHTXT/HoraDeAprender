using System.ComponentModel.DataAnnotations;

namespace HoraDeAprender.API.Models
{
    public class MuralAviso
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; } = string.Empty;
        [Required]
        public string Mensagem { get; set; } = string.Empty;
        public string Autor { get; set; } = "Administrador";
        public DateTime DataPublicacao { get; set; } = DateTime.Now;
    }
}
