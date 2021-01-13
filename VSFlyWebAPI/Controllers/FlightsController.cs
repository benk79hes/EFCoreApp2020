using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFCoreApp2020E;
using VSFlyWebAPI.Extensions;

namespace VSFlyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly WWWingsContext _context;


        public FlightsController(WWWingsContext context)
        {
            _context = context;
        }


        // GET: api/Flights
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.FlightM>>> GetFlightSet()
        {
            var flightList =  await _context.FlightSet.ToListAsync();
            List<Models.FlightM> listFlightM = new List<Models.FlightM>();
            foreach( Flight f in flightList)
            {
                var fM = f.ConvertToFlightM();

                if (f.BookingSet.Count >= f.Seats) {
                    continue;
                }

                listFlightM.Add(fM);
                
            }
            return listFlightM;
        }


        // GET: api/Flights/5/CurrentSalePrice
        [HttpGet("{id}/CurrentSalePrice")]
        public async Task<ActionResult<double>> GetFlightCurrentSalePrice(int id)
        {
            var flight = await _context.FlightSet.FindAsync(id);

            if (flight == null)
            {
                return NotFound();
            }

            Models.FlightM fM = flight.ConvertToFlightM();
            return fM.GetPrice();
        }


        // GET: api/Flights/5/TotalSalePrice
        [HttpGet("{id}/TotalSalePrice")]
        public async Task<ActionResult<double>> GetFlightTotalSalePrice(int id)
        {
            var query = from b in _context.BookingSet
                        where b.FlightNo == id
                        group b by b.FlightNo into r
                        select new
                        {
                            Sum = r.Sum(b => b.PricePaid)
                        };

            try
            {
                var res = await query.FirstAsync();
                return res.Sum;
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
