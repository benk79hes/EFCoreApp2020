using System.Collections.Generic;

namespace EFCoreApp2020E
{
    public class Passenger:Person
    {
        public int Weight { get; set; }

        public virtual ICollection<Booking> BookingSet { get; set; }
    }
}
