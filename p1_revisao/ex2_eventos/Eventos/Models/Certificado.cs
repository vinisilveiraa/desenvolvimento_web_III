using System.ComponentModel.DataAnnotations;

namespace Eventos.Models
{
    public class Certificado
    {
        public int CertificadoId { get; set; }
        [Display(Name="Data de Emissão")]
        public DateOnly Data_Emissao { get; set; }
        public string? Link { get; set; }

        public int InscricaoId { get; set; }
        public Inscricao? Inscricao { get; set; }
    }
}
