using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VSFlyWebAPI.Models
{
    public class FlightM
    {
  
        [Key]
        public int FlightNo { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime Date { get; set; }

        public FlightM(string Departure, string Destination, DateTime Date)
        {
            this.Departure = Departure;
            this.Destination = Destination;
            this.Date = Date;
        }
    }
}
