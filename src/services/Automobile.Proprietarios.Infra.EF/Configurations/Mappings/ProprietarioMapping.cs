using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Automobile.Proprietarios.Domain.Entities;
using Automobile.Proprietarios.Domain.Entities.Objects;

namespace Automobile.Proprietarios.Infra.EF.Configurations.Mappings
{
    public class ProprietarioMapping : IEntityTypeConfiguration<Proprietario>
    {
        public void Configure(EntityTypeBuilder<Proprietario> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.OwnsOne(c => c.Documento, tf =>
            {
                tf.Property(c => c.TipoDocumento)
                    .IsRequired()
                    .HasColumnName("TipoDocumento");


                tf.Property(c => c.NumeroDocumento)
                   .IsRequired()
                   .HasMaxLength(Documento.DocumentoMaxLength)
                   .HasColumnName("NumeroDocumento")
                   .HasColumnType($"varchar({Documento.DocumentoMaxLength})");
            });

            builder.OwnsOne(c => c.Email, tf =>
            {
                tf.Property(c => c.Endereco)
                    .IsRequired()
                    .HasColumnName("Email")
                    .HasColumnType($"varchar({Email.EnderecoMaxLength})");
            });

            builder.HasOne(c => c.Endereco)
                .WithOne(c => c.Proprietario);

            builder.ToTable("Proprietarios");
        }
    }
}