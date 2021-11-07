using GISA.Core.DomainObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GISA.Pessoa.API.Data.Mappings
{
    public class PessoaMapping : IEntityTypeConfiguration<Domain.Pessoa>
    {
        public void Configure(EntityTypeBuilder<Domain.Pessoa> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.NomeCompleto)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Rg)
                .HasColumnType("varchar(12)");

            builder.Property(p => p.Cpf)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.Property(c => c.Telefone)
                .HasColumnType("varchar(20)");

            builder.Property(p => p.Ativo)
                .IsRequired();

            builder.Property(p => p.DataNascimento)
                .HasColumnType("date");

            builder.Property(p => p.TipoPessoaEnum)
                .IsRequired();

            builder.OwnsOne(p => p.Email, tf =>
            {
                tf.Property(p => p.Endereco)
                    .IsRequired()
                    .HasColumnName("Email")
                    .HasColumnType($"varchar({Email.EnderecoMaxLength})");
            });

            builder.ToTable("Pessoas");
        }
    }
}
