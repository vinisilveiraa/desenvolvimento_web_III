using System.ComponentModel.DataAnnotations;

namespace Eventos.Models
{
    public class Participante
    {
        public int ParticipanteId { get; set; }
        public string? Nome { get; set; }
        [Display(Name = "E-mail")]
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        public string? Celular { get; set; }
        [Required]
        public string? Senha { get; set; }

        public int Perfil_ProfissionalId { get; set; }
        public Perfil_Profissional? Perfil_Profissional { get; set; }

    }
}
