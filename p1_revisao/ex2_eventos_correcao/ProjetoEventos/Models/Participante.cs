using System.ComponentModel.DataAnnotations;

namespace ProjetoEventos.Models
{
    public class Participante
    {
        public int ParticipanteId { get; set; }
        [Required]
        public string? Nome { get; set; }
        [Display(Name = "E-mail")]
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        public string? Celular { get; set; }
        [Required]
        public string? Senha { get; set; }
        public int Perfil_profissionalId { get; set; }

        public Perfil_profissional? Perfil_profissional { get; set; }
    }
}
