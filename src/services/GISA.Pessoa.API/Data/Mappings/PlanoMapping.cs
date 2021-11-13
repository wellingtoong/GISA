using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GISA.Pessoa.API.Data.Mappings
{
    public class PlanoMapping : IEntityTypeConfiguration<Domain.Plano>
    {
        public void Configure(EntityTypeBuilder<Domain.Plano> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.TipoPlanoEnum)
                .IsRequired();

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Valor)
                .IsRequired();

            builder.Property(p => p.Ativo)
                .IsRequired();

            builder.ToTable("Planos");
        }
    }
}
