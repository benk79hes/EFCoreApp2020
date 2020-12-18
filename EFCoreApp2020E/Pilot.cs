using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace EFCoreApp2020E
{
    public class Pilot:Employee
    {
        public int? FlightHours { get; set; }

        [JsonIgnore]
        /* reference/lien */
        public virtual ICollection<Flight> FlightAsPilotSet { get; set;  }
    }
}
