using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace EFCoreApp2020
{
    public class Pilot:Employee
    {
        public int? FlightHours { get; set; }

        public virtual ICollection<Flight> FlightAsPilotSet { get; set; }
    }
}
