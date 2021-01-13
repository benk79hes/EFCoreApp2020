using System.Collections.Generic;

namespace EFCoreApp2020E
{
    public class Pilot:Employee
    {
        public int? FlightHours { get; set; }

        public virtual ICollection<Flight> FlightAsPilotSet { get; set;  }
    }
}
