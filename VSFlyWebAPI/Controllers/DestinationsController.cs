using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreApp2020E;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VSFlyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationsController : ControllerBase
    {
        private readonly WWWingsContext _context;

        public DestinationsController(WWWingsContext context)
        {
            _context = context;
        }
        /*
        // GET: api/<DestinationsController>
        [HttpGet]
        public IEnumerable<string> Get()

        {
            var r = _context.FlightSet.Select(element => new { Destination = element.Destination }).Distinct();

            /*
            foreach (var d in r)
            {
                Console.WriteLine("{0} {1} {2}", flight.Date, flight.Destination, flight.Seats);
            }
//            return await _context.BookingSet.ToListAsync();
            // return new string[] { "value1", "value2" };
            return r;
        } */

        // GET api/<DestinationsController>/AveragePrice/LAX
        [HttpGet("AveragePrice/{destination}")]
        public async Task<ActionResult<double>> GetDestinationAveragePrice(string destination)
        {
           
            double totalPrice=0;
            int count=0;
            foreach (Flight f in _context.FlightSet) {
                if (f.Destination.Equals(destination)){
                    foreach (Booking b in f.BookingSet) {
                        totalPrice += b.PricePaid;
                        count++;
                    }
                }
            }

            return (totalPrice/count);
        }

        // GET api/<DestinationsController>/5
        [HttpGet("Bookings/{destination}")]
        public async Task<ActionResult<double>> GetDestinationBookings(string destination)
        {

            return 25.5;
        }
        /*
        // POST api/<DestinationsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DestinationsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DestinationsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        } */
    }
}
