using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VSFlyWebAPI.Models
{
    public class Ticket
    {
        public int FlightNo { get; set; }
        public string Surname { get; set; }
        public string GivenName { get; set; }
        public double PricePaid { get; set; }
    }
}
