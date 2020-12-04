using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreApp2020
{
    public class Passenger:Person
    {
        public int Weight { get; set; }

        public virtual ICollection<Booking> BookingSet { get; set; }
    }
}
