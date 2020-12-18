using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VSFlyWebAPI.Extensions
{
    public static class ConverterExtensions
    {
        public static EFCoreApp2020E.Flight ConvertToFlightEF(this Models.FlightM f) 
        {
            var restFlight = new EFCoreApp2020E.Flight();
            restFlight.Seats = 300;
            restFlight.Date = f.Date;
            restFlight.Departure = f.Departure;
            restFlight.Destination = f.Destination;

            return restFlight;
        }
    }
}
