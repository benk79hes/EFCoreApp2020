using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreApp2020E
{
    public class Passenger:Person
    {
        public int Weight { get; set; }

        // Flight <---------------- Booking -------------------> Passenger
        public virtual ICollection<Booking> BookingSet { get; set; }
    }
}
