using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GISA.Pessoa.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Domain.Pessoa> Pessoas { get; set; }
        public DbSet<Domain.Endereco> Enderecos { get; set; }
        public DbSet<Domain.Plano> Planos { get; set; }

        public DbSet<Domain.PlanoCliente> PlanoClientes { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string)))) property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
