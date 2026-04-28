using System.Numerics;
using ex1_clinica.Models;
using Microsoft.EntityFrameworkCore;
using VasosInteligentes.Models;

namespace VasosInteligentes.Data
{
    public class FakeContext : DbContext
    {
        public DbSet<Clinica> Clinica { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Banco Temporario");
        }
    }
}