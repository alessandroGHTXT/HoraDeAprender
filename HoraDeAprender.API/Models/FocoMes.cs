namespace HoraDeAprender.API.Models
{
    public class FocoMes
    {
        public int Id { get; set; }
        public string MesAno { get; set; } = string.Empty;
        public string Tema { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
    }
}