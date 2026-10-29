namespace HoraDeAprender.API.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Serie { get; set; }        // <--- Garante que isto está aqui
        public required string Responsavel { get; set; }  // <--- E isto também
        public required string Email { get; set; }
        public required string Telefone { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
    }
}