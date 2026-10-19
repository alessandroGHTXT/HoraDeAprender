namespace HoraDeAprender.API.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; } = string.Empty;
        public string Serie { get; set; } = string.Empty;
        public string NomeResponsavel { get; set; } = string.Empty;
        public string ContatoResponsavel { get; set; } = string.Empty;
    }
}