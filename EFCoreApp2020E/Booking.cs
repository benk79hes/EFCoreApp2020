

namespace EFCoreApp2020E
{
    public class Booking
    {   
        public int FlightNo { get; set; } 

        public int PassengerID { get; set; }

        public double PricePaid { get; set; }

        public virtual Flight Flight { get; set; }

        public virtual Passenger Passenger { get; set;  }
    }
}
