using System;
using System.Net.Http;

namespace ConsoleTestVSFly
{
    class Program
    {
        static void Main(string[] args)
        {
            var http = new HttpClient();
            var client = new swaggerClient("https://localhost:44349/", http);
            var listFlight = client.FlightsAllAsync() ;
            
            foreach (FlightM flight in listFlight)
            {
                Console.WriteLine(flight.Departure);
            }

        }
    }
}
