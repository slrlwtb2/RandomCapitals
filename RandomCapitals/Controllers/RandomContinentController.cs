using Microsoft.AspNetCore.Mvc;
using RandomCapitals.ModelRequest;
using RandomContinent.Model;
using RandomContinent.Service;

namespace RandomContinent.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RandomContinentController : ControllerBase
    {
        private readonly RandomContinentService _randomContinent;
        public Player player1 = new Player();
        public Player player2 = new Player();

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
        [HttpPost]
        public IActionResult CreatePlayer(CreatePlayerRequest model)
        {
            if (ModelState.IsValid)
            {
                player1.Name = model.Player1;
                player1.Continent = model.Player1Continent;

                player2.Name = model.Player2;
                player2.Continent = model.Player2Continent;
                return Ok(new { Player1 = player1, Player2 = player2 }); 
            }
            return BadRequest("Modelstate not valid");
        }


    }
}
