﻿using Microsoft.EntityFrameworkCore;

namespace EFCoreApp2020E
{
    public class WWWingsContext : DbContext
    {
        public DbSet<Flight> FlightSet { get; set; }
       
        public DbSet<Pilot> PilotSet { get; set; }
        
        public DbSet<Passenger> PassengerSet { get; set; }
        
        public DbSet<Booking> BookingSet { get; set; }

        public static string ConnectionString { get; set; } = @"Server=(localDB)\MSSQLLocalDB;Database=WWWings_2021;Trusted_Connection=True;MultipleActiveResultSets=True;App=EFCoreApp2020E";
        
        public WWWingsContext() { 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            builder.UseSqlServer(ConnectionString);

            builder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            // composed key
            builder.Entity<Booking>().HasKey(x => new { x.FlightNo, x.PassengerID });

            // mapping many to many relationship
            builder.Entity<Booking>()
                .HasOne(x => x.Flight)
                .WithMany(x => x.BookingSet)
                .HasForeignKey(x => x.FlightNo)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Booking>()
                .HasOne(x => x.Passenger)
                .WithMany(x => x.BookingSet)
                .HasForeignKey(x => x.PassengerID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
