using System.ComponentModel.DataAnnotations;

namespace HoraDeAprender.API.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        public string SenhaHash { get; set; } = string.Empty;
        
        public string Perfil { get; set; } = "Usuario";
    }
}