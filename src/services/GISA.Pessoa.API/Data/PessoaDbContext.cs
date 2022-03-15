using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GISA.Pessoa.API.Data
{
    public class PessoaDbContext : DbContext
    {
        public PessoaDbContext(DbContextOptions<PessoaDbContext> options)
            : base(options) { }

        public DbSet<Domain.Pessoa> Pessoas { get; set; }
        public DbSet<Domain.EnderecoPessoa> EnderecoPessoa { get; set; }
        public DbSet<Domain.Plano> Planos { get; set; }
        public DbSet<Domain.PlanoCliente> PlanoClientes { get; private set; }
        public DbSet<Domain.Agenda> Agendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(100)");
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PessoaDbContext).Assembly);
        }
    }
}
