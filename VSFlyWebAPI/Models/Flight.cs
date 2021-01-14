using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VSFlyWebAPI.Models
{
    public class Flight
    {
        public int FlightNo { get; set; }

        public string Departure { get; set; }

        public string Destination { get; set; }
        public DateTime Date { get; set; }

        public short? Seats { get; set; }
        public short AvailableSeats { get; set; }

        public double SeatPrice { get; set; }

        public double GetPrice()
        {

            if (AvailableSeats < (Seats * 20 / 100))
            {
                return SeatPrice * 150 / 100;
            }

            if (AvailableSeats > (Seats / 2) && DateTime.Now.AddMonths(1) > Date)
            {
                return SeatPrice * 70 / 100;
            }
           
            if (AvailableSeats > (Seats * 80 / 100 ) && DateTime.Now.AddMonths(2) > Date)
            {
                return SeatPrice * 80 / 100;
            }
            
            return SeatPrice;

        }
    }
}
