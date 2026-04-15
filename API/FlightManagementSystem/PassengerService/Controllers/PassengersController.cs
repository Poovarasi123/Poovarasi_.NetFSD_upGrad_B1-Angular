using Microsoft.AspNetCore.Mvc;
using PassengerService.Models;

namespace PassengerService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PassengersController : ControllerBase
    {
        private static List<Passenger> passengers = new List<Passenger>()
        {
            new Passenger { PassengerId = 201, Name = "John Doe", Age = 30 }
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(passengers);
        }

        [HttpPost]
        public IActionResult AddPassenger(Passenger passenger)
        {
            passengers.Add(passenger);
            return Ok(passenger);
        }
    }
}