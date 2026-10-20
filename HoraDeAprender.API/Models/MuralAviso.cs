namespace HoraDeAprender.API.Models
{
    public class MuralAviso
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Mensagem { get; set; } = string.Empty;
        public DateTime DataPublicacao { get; set; } = DateTime.Now;
    }
}