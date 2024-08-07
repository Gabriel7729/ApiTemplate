﻿// <auto-generated />
using System;
using ApiTemplate.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiTemplate.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240622172700_VerificationCodeTable")]
    partial class VerificationCodeTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ApiTemplate.Core.Entities.CarfaxAggregate.Vehiculo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Anio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CantidadMillas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CantidadPasajeros")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("DeletedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Motor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Vehiculos");
                });

            modelBuilder.Entity("ApiTemplate.Core.Entities.CarfaxAggregate.VehiculoEvento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("DeletedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("VehiculoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("VehiculoId");

                    b.ToTable("VehiculoEventos");
                });

            modelBuilder.Entity("ApiTemplate.Core.Entities.PersonasAggregate.Persona", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("DeletedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaNacimiento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("ApiTemplate.Core.Entities.ValidationsAggregate.VerificationCode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Attemps")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("DeletedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SentTo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("UpdatedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("VerificationCodes");
                });

            modelBuilder.Entity("ApiTemplate.Core.Entities.CarfaxAggregate.VehiculoEvento", b =>
                {
                    b.HasOne("ApiTemplate.Core.Entities.CarfaxAggregate.Vehiculo", null)
                        .WithMany("Eventos")
                        .HasForeignKey("VehiculoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ApiTemplate.Core.Entities.CarfaxAggregate.Vehiculo", b =>
                {
                    b.Navigation("Eventos");
                });
#pragma warning restore 612, 618
        }
    }
}
