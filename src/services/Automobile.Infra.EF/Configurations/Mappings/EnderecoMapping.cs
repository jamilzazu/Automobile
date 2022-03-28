using Automobile.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Automobile.Infra.EF.Configurations.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Logradouro)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Numero)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Cep)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(c => c.Complemento)
                .HasColumnType("varchar(250)");

            builder.Property(c => c.Bairro)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.CodigoIbgeCidade)
                .IsRequired()
                .HasPrecision(7, 0);

            builder.Property(c => c.CodigoIbgeEstado)
                .IsRequired()
                .HasPrecision(7, 0);

            builder.ToTable("ProprietarioEnderecos");
        }
    }
}