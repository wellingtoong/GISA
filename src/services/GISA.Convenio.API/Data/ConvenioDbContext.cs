using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GISA.Convenio.API.Data
{
    public class ConvenioDbContext : DbContext
    {
        public ConvenioDbContext(DbContextOptions<ConvenioDbContext> options)
            : base(options) { }

        public DbSet<Domain.Convenio> Convenios { get; set; }
        public DbSet<Domain.EnderecoConvenio> EnderecoConvenio { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string)))) property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ConvenioDbContext).Assembly);
        }
    }
}
