using System;
using System.Linq;

namespace EFCoreApp2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var ctx = new WWWingsContext();

            var e = ctx.Database.EnsureCreated();

            if (e)
            {
                Console.WriteLine("Database has been created !");
            }

            var data = from f in ctx.FlightSet select f;

            foreach (Flight flight in data)
            {
                Console.WriteLine("{0} {1} {2}", flight.Departure, flight.Destination, flight.Date);
            }

            // Insérer
            ctx.FlightSet.Add(new Flight { Departure = "Lausanne", Destination = "Lutry", Date = DateTime.Parse("2020-02-01"), Seats = 120});
            
            // Modifier

            // Supprimer
        }
    }
}
