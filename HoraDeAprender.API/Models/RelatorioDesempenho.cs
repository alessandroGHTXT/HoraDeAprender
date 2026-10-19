namespace HoraDeAprender.API.Models
{
    public class RelatorioDesempenho
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public string Mes { get; set; } = string.Empty;
        public string Comentarios { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}