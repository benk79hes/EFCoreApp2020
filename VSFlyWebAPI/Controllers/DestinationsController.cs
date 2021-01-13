using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreApp2020E;
using Microsoft.EntityFrameworkCore;


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


        // GET api/<DestinationsController>/AveragePrice/LAX
        [HttpGet("AveragePrice/{destination}")]
        public async Task<ActionResult<double>> GetDestinationAveragePrice(string destination)
        {
            double result;

            var query = from f in _context.FlightSet
                        join b in _context.BookingSet on f.FlightNo equals b.FlightNo
                        select new
                        {
                            PricePaid = b.PricePaid,
                            Destination = f.Destination
                        };

            try
            {
                result = await query.Where(x => x.Destination == destination).AverageAsync(x => x.PricePaid);
            } catch
            {
                result = 0;
            }

            return result;
        }


        // GET api/<DestinationsController>/Bookings/LAX
        [HttpGet("Bookings/{destination}")]
        public async Task<ActionResult<IEnumerable<Models.TicketSold>>> GetDestinationBookings(string destination)
        {
            List <Models.TicketSold> tickets = new List<Models.TicketSold>();

            var query = from f in _context.FlightSet
                        join b in _context.BookingSet on f.FlightNo equals b.FlightNo
                        join p in _context.PassengerSet on b.PassengerID equals p.PersonID
                        where f.Destination == destination
                        select new Models.TicketSold { 
                            FlightNo = f.FlightNo,
                            Surname = p.Surname,
                            GivenName = p.GivenName,
                            PricePaid = b.PricePaid
                        };

            return await query.ToListAsync();
        }
    }
}
