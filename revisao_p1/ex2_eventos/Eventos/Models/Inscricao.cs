using System.ComponentModel.DataAnnotations;

namespace Eventos.Models
{
    public class Inscricao
    {
        public int InscricaoId { get; set; }
        [Display(Name = "Data de Inscrição")]
        public DateOnly Data_Inscricao { get; set; }

        public int EventoId { get; set; }
        public Evento? Evento { get; set; }
        public int ParticipanteId { get; set; }
        public Participante? Participante { get; set; }
    }
}
