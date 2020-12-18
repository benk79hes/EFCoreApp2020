using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleTestVSFly
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var http = new HttpClient();
            var client = new swaggerClient("https://localhost:44349/", http);
            var listFlight = await client.FlightsAllAsync();
            
            foreach (FlightM flight in listFlight)
            {
                Console.WriteLine(flight.Departure);
            }

        }
    }
}
