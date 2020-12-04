using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreApp2020
{
    public class Booking
    {
        public int FlightNo { get; set; }


        public int PassengerId { get; set; }

        public virtual Flight Flight { get; set; }

        public virtual Passenger Passenger { get; set; }

    }
}
