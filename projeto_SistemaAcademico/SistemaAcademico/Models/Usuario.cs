namespace SistemaAcademico.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        public string? Nome { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public Aluno? Aluno { get; set; }
    }
}
