namespace HoraDeAprender.API.Models
{
    public class PreCadastro
    {
        public int Id { get; set; }
        public string NomeAluno { get; set; } = string.Empty;
        public string Serie { get; set; } = string.Empty;
        public string NomeResponsavel { get; set; } = string.Empty;
        public string EmailResponsavel { get; set; } = string.Empty;
        public string TelefoneResponsavel { get; set; } = string.Empty;
        public DateTime DataSolicitacao { get; set; } = DateTime.Now;
        public bool Aprovado { get; set; } = false;
    }
}