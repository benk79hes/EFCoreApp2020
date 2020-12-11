using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace EFCoreApp2020
{
    public class Passenger:Person
    {
        public int Weight { get; set; }

        public virtual ICollection<Booking> BookingSet { get; set; }
    }
}
