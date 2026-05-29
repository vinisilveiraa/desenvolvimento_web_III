using Eventos.Models;
using Microsoft.EntityFrameworkCore;

namespace Eventos.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Certificado> Certificados { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Inscricao> Inscricoes { get; set; }
        public DbSet<Participante> Participantes { get; set; }
        public DbSet<Patrocinador> Patrocinadores { get; set; }
        public DbSet<Perfil_Profissional> Perfil_Profissionais { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
    }
}
