using DCGP.TesteGol.Domain;
using DCGP.TesteGol.Infra.Maps;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DCGP.TesteGol.Infra.EF
{
    public class DataContext: DbContext
    {
        private readonly IConfiguration _config;

        public DbSet<Airplane> Airplanes { get; set; }

        public DataContext()
        {

        }

        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Database.EnsureCreated();
            modelBuilder.ApplyConfiguration(new AirplaneMap());
        }
    }
}
