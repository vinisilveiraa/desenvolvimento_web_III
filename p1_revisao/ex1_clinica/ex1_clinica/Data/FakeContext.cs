using System.Numerics;
using ex1_clinica.Models;
using Microsoft.EntityFrameworkCore;

// O FAKE CONTEXT FAZ UM BANCO FAKE PARA FACILITAR A CONSTRUCAO NO MONGO

namespace ex1_clinica.Data
{
    // simula um banco
    public class FakeContext : DbContext
    {
        // representa a tablema em memoria
        public DbSet<Clinica> Clinica { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // cria um banco fake na memoria
            optionsBuilder.UseInMemoryDatabase("Banco Temporario");
        }
    }
}