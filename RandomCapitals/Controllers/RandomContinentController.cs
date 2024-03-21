using Microsoft.AspNetCore.Mvc;
using RandomContinent.Service;

namespace RandomContinent.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RandomContinentController : ControllerBase
    {
        private readonly RandomContinentService _randomContinent;
        public RandomContinentController(RandomContinentService randomContinent)
        {
             _randomContinent = randomContinent;
        }
        [HttpGet]
        public IActionResult RandomContinent()
        {
            var coordinates = _randomContinent.GenerateRandomCoordinates();
            return Ok(new { Player1Coordinates = coordinates[0], Player2Coordinates = coordinates[1] });
        }
    }
}
