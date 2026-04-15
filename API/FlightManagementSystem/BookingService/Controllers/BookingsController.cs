using Microsoft.AspNetCore.Mvc;
using BookingService.Models;

namespace BookingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : ControllerBase
    {
        private static List<Booking> bookings = new List<Booking>()
        {
            new Booking { BookingId = 101, FlightId = 1, PassengerId = 201 }
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(bookings);
        }

        [HttpPost]
        public IActionResult AddBooking(Booking booking)
        {
            bookings.Add(booking);
            return Ok(booking);
        }
    }
}