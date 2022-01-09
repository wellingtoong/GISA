using GISA.Core.DomainObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GISA.Convenio.API.Data.Mappings
{
    public class ConvenioMapping : IEntityTypeConfiguration<Domain.Convenio>
    {
        public void Configure(EntityTypeBuilder<Domain.Convenio> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.NomeFantasia)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.RazaoSocial)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.InscricaoMunicipal)
                .HasColumnType("varchar(200)");

            builder.Property(c => c.InscricaoEstadual)
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Cnpj)
                .IsRequired()
                .HasColumnType("varchar(18)");

            builder.Property(c => c.Telefone)
                .HasColumnType("varchar(20)");

            builder.Property(c => c.Ativo)
                .IsRequired();

            builder.Property(c => c.DataCadastro)
                .IsRequired();

            builder.OwnsOne(c => c.Email, tf =>
            {
                tf.Property(c => c.Endereco)
                    .IsRequired()
                    .HasColumnName("Email")
                    .HasColumnType($"varchar({Email.EnderecoMaxLength})");
            });

            // 1 : 1 => Convenio : Endereco
            builder.HasOne(c => c.Endereco)
                .WithOne(e => e.Convenio);

            builder.ToTable("Convenios");
        }
    }
}
