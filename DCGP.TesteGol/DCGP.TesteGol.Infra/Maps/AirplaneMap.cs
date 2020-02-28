using DCGP.TesteGol.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DCGP.TesteGol.Infra.Maps
{
    public class AirplaneMap : IEntityTypeConfiguration<Airplane>
    {
        public void Configure(EntityTypeBuilder<Airplane> builder)
        {
            builder.ToTable(nameof(Airplane));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Modelo)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.QtdPassageiros)
                .IsRequired();

            builder.Property(x => x.DataCriacaoRegistro);
        }
    }
}
