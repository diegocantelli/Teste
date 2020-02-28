﻿// <auto-generated />
using System;
using DCGP.TesteGol.Infra.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DCGP.TesteGol.Infra.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200227154347_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DCGP.TesteGol.Domain.Airplane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCriacaoRegistro");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("QtdPassageiros");

                    b.HasKey("Id");

                    b.ToTable("Airplane");
                });
#pragma warning restore 612, 618
        }
    }
}