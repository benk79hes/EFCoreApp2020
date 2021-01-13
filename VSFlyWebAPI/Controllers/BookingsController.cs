using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFCoreApp2020E;

namespace VSFlyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly WWWingsContext _context;


        public BookingsController(WWWingsContext context)
        {
            _context = context;
        }


        // POST: api/Bookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostBooking(Models.BookingM bM)
        {
            Console.WriteLine(bM);
            Passenger p = new Passenger { Surname = bM.Surname, GivenName = bM.GivenName, Weight = bM.Weight };

            _context.PassengerSet.Add(p);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }
           
            Booking b = new Booking { FlightNo = bM.FlightNo, PassengerID = p.PersonID, PricePaid = bM.Price };
            _context.BookingSet.Add(b);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            } 

            return NoContent();
        }
    }
}
