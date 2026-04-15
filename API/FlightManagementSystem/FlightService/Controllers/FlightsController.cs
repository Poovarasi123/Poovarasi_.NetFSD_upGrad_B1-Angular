using Microsoft.AspNetCore.Mvc;
using FlightService.Models;

namespace FlightService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightsController : ControllerBase
    {
        private static List<Flight> flights = new List<Flight>()
        {
            new Flight { Id = 1, FlightNumber = "AI101", Source = "Hyderabad", Destination = "Delhi" }
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(flights);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var flight = flights.FirstOrDefault(f => f.Id == id);
            if (flight == null) return NotFound();
            return Ok(flight);
        }

        [HttpPost]
        public IActionResult AddFlight(Flight flight)
        {
            flights.Add(flight);
            return Ok(flight);
        }
    }
}