using Automobile.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Automobile.Infra.EF.Configurations.Mappings
{
    public class VeiculoMapping : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Renavam)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Quilometragem)
                .IsRequired();

            builder.Property(c => c.Valor)
                .IsRequired();

            builder.HasOne(c => c.Modelo)
            .WithOne(c => c.Veiculo);

            builder.HasOne(c => c.Proprietario)
            .WithOne(c => c.Veiculo);

            builder.HasOne(c => c.Marca)
            .WithOne(c => c.Veiculo);

            builder.ToTable("Veiculos");
        }
    }
}