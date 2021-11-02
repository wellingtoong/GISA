using Microsoft.EntityFrameworkCore;

namespace GISA.Convenio.API.Data
{
    public class ConvenioDbContext : DbContext
    {
        public ConvenioDbContext(DbContextOptions<ConvenioDbContext> options) 
            : base(options) { }

        public DbSet<Domain.Convenio> Convenios { get; set; }
        public DbSet<Domain.Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ConvenioDbContext).Assembly);
        }
    }
}
