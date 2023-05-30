﻿// <auto-generated />
using System;
using ContratosToyyoda.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ContratosToyyoda.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230530143349_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ContratosToyyoda.Models.Apoderado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TipoDoc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("domicilio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("estadoFamiliar")
                        .HasColumnType("int");

                    b.Property<DateTime>("fechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("nacionalidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("numDocId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("profesion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("sexo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Apoderados");
                });

            modelBuilder.Entity("ContratosToyyoda.Models.Contrato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TipoDoc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cargo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("domicilio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("estadoFamiliar")
                        .HasColumnType("int");

                    b.Property<DateTime>("fechaEmision")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaIngreso")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("idPais")
                        .HasColumnType("int");

                    b.Property<int>("idUser")
                        .HasColumnType("int");

                    b.Property<string>("nacionalidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("numDocId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("profesion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("sexo")
                        .HasColumnType("int");

                    b.Property<double>("sueldo")
                        .HasColumnType("float");

                    b.Property<int>("tipoContrato")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("idPais");

                    b.HasIndex("idUser");

                    b.ToTable("Contratos");
                });

            modelBuilder.Entity("ContratosToyyoda.Models.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idApoderado")
                        .HasColumnType("int");

                    b.Property<string>("logo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("pais")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("idApoderado");

                    b.ToTable("Paises");
                });

            modelBuilder.Entity("ContratosToyyoda.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contrasena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ContratosToyyoda.Models.Contrato", b =>
                {
                    b.HasOne("ContratosToyyoda.Models.Pais", "pais")
                        .WithMany()
                        .HasForeignKey("idPais")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ContratosToyyoda.Models.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("idUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("pais");

                    b.Navigation("usuario");
                });

            modelBuilder.Entity("ContratosToyyoda.Models.Pais", b =>
                {
                    b.HasOne("ContratosToyyoda.Models.Apoderado", "apoderado")
                        .WithMany()
                        .HasForeignKey("idApoderado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("apoderado");
                });
#pragma warning restore 612, 618
        }
    }
}