namespace HoraDeAprender.API.Models
{
    public class RegisterDto
    {
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string Perfil { get; set; } = "Aluno"; // Valor padrão: "Aluno" ou "Professor"
    }
}