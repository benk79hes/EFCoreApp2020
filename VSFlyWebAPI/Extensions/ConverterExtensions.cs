using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VSFlyWebAPI.Extensions
{
    public static class ConverterExtensions
    {
        public static EFCoreApp2020E.Flight ConvertToFlightEF(this Models.Flight f) 
        {
            var refFlight = new EFCoreApp2020E.Flight();
            refFlight.FlightNo = f.FlightNo;
            refFlight.Seats = f.Seats;
            refFlight.Date = f.Date;
            refFlight.Departure = f.Departure;
            refFlight.Destination = f.Destination;

            return refFlight;
        }

        public static Models.Flight ConvertToFlightM(this EFCoreApp2020E.Flight f) {

            Models.Flight fM = new Models.Flight();
            
            fM.FlightNo = f.FlightNo;
            fM.Date = f.Date;
            fM.Departure = f.Departure;
            fM.Destination = f.Destination;
            /**
             * @TODO  Remove ? 
             **/
            fM.Seats = f.Seats;
            fM.AvailableSeats = (short)(f.Seats - f.BookingSet.Count);
            fM.SeatPrice = f.BasePrice;

            return fM;
        }

        public static Models.Booking ConvertToBookingM(this EFCoreApp2020E.Booking b) {

            Models.Booking bM = new Models.Booking();
            bM.Surname = b.Passenger.Surname;
            bM.GivenName = b.Passenger.GivenName;
            bM.Weight = b.Passenger.Weight;
            bM.FlightNo = b.FlightNo;
            bM.Price = b.PricePaid;

            return bM;
        }
    }
}
