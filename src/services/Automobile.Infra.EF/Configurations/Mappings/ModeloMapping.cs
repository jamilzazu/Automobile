using Automobile.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Automobile.Infra.EF.Configurations.Mappings
{
    public class ModeloMapping : IEntityTypeConfiguration<Modelo>
    {
        public void Configure(EntityTypeBuilder<Modelo> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.AnoModelo)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.AnoFabricacao)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.ToTable("Modelos");
        }
    }
}