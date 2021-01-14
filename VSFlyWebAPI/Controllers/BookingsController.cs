using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFCoreApp2020E;
using VSFlyWebAPI.Extensions;

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
        public async Task<ActionResult<Models.BookingError>> PostBooking(Models.Booking bM)
        {
            Console.WriteLine(bM);

            Flight f = _context.FlightSet.Find(bM.FlightNo);
            if (f == null) {
                return new Models.BookingError(404, "The flight was not find, please try again");           
            }
            Models.Flight fM = f.ConvertToFlightM();
            if (fM.AvailableSeats <= 0) {
                return new Models.BookingError(99, "The selected flight is already full");
            }
            if (fM.Date < DateTime.Now) {
                return new Models.BookingError(36, "The selected flight is not available");
            }
            var calculatedPrice = fM.GetPrice();
            Console.WriteLine(calculatedPrice);
            if (!fM.GetPrice().Equals(bM.Price)) {
                return new Models.BookingError(103, "The selected price does not match. Please retry the booking");
            }

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

            return new Models.BookingError(500, "The booking was successfully registered");
        }
    }
}
