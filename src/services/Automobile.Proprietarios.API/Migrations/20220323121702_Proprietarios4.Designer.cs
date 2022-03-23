﻿// <auto-generated />
using System;
using Automobile.Proprietarios.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Automobile.Proprietarios.API.Migrations
{
    [DbContext(typeof(ProprietariosContext))]
    [Migration("20220323121702_Proprietarios4")]
    partial class Proprietarios4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Automobile.Proprietarios.API.Models.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Complemento")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("ProprietarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProprietarioId")
                        .IsUnique();

                    b.ToTable("ProprietarioEnderecos");
                });

            modelBuilder.Entity("Automobile.Proprietarios.API.Models.Proprietario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Cancelado")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Proprietarios");
                });

            modelBuilder.Entity("Automobile.Proprietarios.API.Models.Endereco", b =>
                {
                    b.HasOne("Automobile.Proprietarios.API.Models.Proprietario", "Proprietario")
                        .WithOne("Endereco")
                        .HasForeignKey("Automobile.Proprietarios.API.Models.Endereco", "ProprietarioId")
                        .IsRequired();
                });

            modelBuilder.Entity("Automobile.Proprietarios.API.Models.Proprietario", b =>
                {
                    b.OwnsOne("Automobile.Core.DomainObjects.Cpf", "Cpf", b1 =>
                        {
                            b1.Property<Guid>("ProprietarioId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasColumnName("Cpf")
                                .HasColumnType("varchar(11)")
                                .HasMaxLength(11);

                            b1.HasKey("ProprietarioId");

                            b1.ToTable("Proprietarios");

                            b1.WithOwner()
                                .HasForeignKey("ProprietarioId");
                        });

                    b.OwnsOne("Automobile.Core.DomainObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("ProprietarioId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Endereco")
                                .IsRequired()
                                .HasColumnName("Email")
                                .HasColumnType("varchar(254)");

                            b1.HasKey("ProprietarioId");

                            b1.ToTable("Proprietarios");

                            b1.WithOwner()
                                .HasForeignKey("ProprietarioId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
