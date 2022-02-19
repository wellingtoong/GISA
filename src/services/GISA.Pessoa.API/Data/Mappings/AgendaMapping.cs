using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GISA.Pessoa.API.Data.Mappings
{
    public class AgendaMapping : IEntityTypeConfiguration<Domain.Agenda>
    {
        public void Configure(EntityTypeBuilder<Domain.Agenda> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.IdPessoa)
                .IsRequired();

            builder.Property(a => a.Data)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(a => a.Hora)
                .IsRequired()
                .HasColumnType("varchar(5)");

            builder.Property(a => a.Observacao)
                .HasColumnType("varchar(200)");

            builder.Property(a => a.DataCadastro)
                .IsRequired()
                .HasColumnType("date");

            builder.ToTable("Agendas");
        }
    }
}
