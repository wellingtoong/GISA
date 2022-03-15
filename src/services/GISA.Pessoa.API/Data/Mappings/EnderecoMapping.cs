using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GISA.Pessoa.API.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Domain.EnderecoPessoa>
    {
        public void Configure(EntityTypeBuilder<Domain.EnderecoPessoa> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Cep)
                .IsRequired()
                .HasColumnType("varchar(9)");

            builder.Property(e => e.Logradouro)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(e => e.Numero)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(e => e.Complemento)
                .HasColumnType("varchar(200)");

            builder.Property(e => e.Bairro)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(e => e.Estado)
                .IsRequired()
                .HasColumnType("varchar(2)");

            builder.Property(e => e.Municipio)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(e => e.DataCadastro)
                .IsRequired();

            builder.ToTable("EnderecoPessoa");
        }
    }
}
