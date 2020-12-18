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
            var refFlight = new EFCoreApp2020E.Flight();
            refFlight.FlightNo = f.FlightNo;
            refFlight.Seats = f.Seats;
            refFlight.Date = f.Date;
            refFlight.Departure = f.Departure;
            refFlight.Destination = f.Destination;

            return refFlight;
        }

        public static Models.FlightM ConvertToFlightM(this EFCoreApp2020E.Flight f) {

            Models.FlightM fM = new Models.FlightM();
            
            fM.FlightNo = f.FlightNo;
            fM.Date = f.Date;
            fM.Departure = f.Departure;
            fM.Destination = f.Destination;
            fM.Seats = f.Seats;

            return fM;
        }
    }
}
