

using Microsoft.EntityFrameworkCore;
using ProjetoEventos.Models;

namespace ProjetoEventos.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Participante> Participantes { get; set; }
        public DbSet<Patrocinador> Patrocinadores { get; set; }
        public DbSet<Inscricao> Inscricao { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Certificado> Certificados { get; set; }
        public DbSet<Perfil_profissional> Perfis_profissionais { get; set; }
    }
}
