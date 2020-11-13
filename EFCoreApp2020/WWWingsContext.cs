using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreApp2020
{
    public class WWWingsContext : DbContext
    {
        public static string ConnectionString { get; set; } = @"Server=(localDB)\MSSQLLocalDB;Database=WWWings_2020Step1;Trusted_Connection=true;MultipleActiveResultSets=True;App=EFCoreApp2020";

        public DbSet<Flight> FlightSet { get; set; }

        public WWWingsContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(ConnectionString);
        }
    }
}
