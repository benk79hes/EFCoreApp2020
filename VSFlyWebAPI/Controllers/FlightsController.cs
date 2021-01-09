using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        /*
        // GET: api/Flights/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.FlightM>> GetFlight(int id)
        {
            var flight = await _context.FlightSet.FindAsync(id);

            if (flight == null)
            {
                return NotFound();
            }

            return flight.ConvertToFlightM();
        }
        */

        // GET: api/Flights/5
        [HttpGet("{id}/CurrentSalePrice")]
        public async Task<ActionResult<double>> GetFlightCurrentSalePrice(int id)
        {
            var flight = await _context.FlightSet.FindAsync(id);

            if (flight == null)
            {
                return NotFound();
            }

            //return flight.ConvertToFlightM();
            return 2.0;
        }

        // GET: api/Flights/5
        [HttpGet("{id}/TotalSalePrice")]
        public async Task<ActionResult<double>> GetFlightTotalSalePrice(int id)
        {
            var flight = await _context.FlightSet.FindAsync(id);

            if (flight == null)
            {
                return NotFound();
            }

            //return flight.ConvertToFlightM();
            return 2.0;
        }
    }
}
