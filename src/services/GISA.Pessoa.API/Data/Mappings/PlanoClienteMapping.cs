using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GISA.Pessoa.API.Data.Mappings
{
    public class PlanoClienteMapping : IEntityTypeConfiguration<Domain.PlanoCliente>
    {
        public void Configure(EntityTypeBuilder<Domain.PlanoCliente> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.PessoaId)
                .IsRequired();

            builder.Property(p => p.PlanoId)
                .IsRequired();

            builder.Property(p => p.Desconto)
                .HasColumnType("int");

            builder.Property(p => p.ValorFinal)
                .HasColumnType("decimal(5,2)");

            builder.Property(p => p.DataCadastro)
               .IsRequired();

            builder.ToTable("PlanoClientes");
        }
    }
}
