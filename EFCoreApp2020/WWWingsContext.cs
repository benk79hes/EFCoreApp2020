using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreApp2020
{
    public class WWWingsContext : DbContext
    {
        public static string ConnectionString { get; set; } = @"Server=(localDB)\MSSQLLocalDB;Database=WWWings_2020Step5;Trusted_Connection=true;MultipleActiveResultSets=True;App=EFCoreApp2020";

        public DbSet<Flight> FlightSet { get; set; }


        public DbSet<Pilot> PilotSet { get; set; }
        public DbSet<Passenger> PassengerSet { get; set; }
        
        public DbSet<Booking> BookingSet { get; set; }

        public WWWingsContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Booking>().HasKey(x => new { x.FlightNo, x.PassengerId});


            builder.Entity<Booking>().HasOne(x => x.Flight)
                .WithMany(x => x.BookingSet)
                .HasForeignKey(x => x.FlightNo)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Booking>().HasOne(x => x.Passenger)
                .WithMany(x => x.BookingSet)
                .HasForeignKey(x => x.PassengerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
