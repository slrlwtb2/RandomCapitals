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
        public static Player player1 = new Player();
        public static Player player2 = new Player();

        public RandomContinentController(RandomContinentService randomContinent)
        {
             _randomContinent = randomContinent;
        }
        [HttpGet("Get")]
        public IActionResult GetPlayers()
        {
            return Ok(new { Player1 = player1, Player2 = player2 });
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
        [HttpPut("Player1Money")]
        public IActionResult Player1Money(int amount)
        {
            player1.Money = player1.Money + amount;
            return Ok(player1);
        }
        [HttpPut("Player2Money")]
        public IActionResult DecreasePlayer1Money(int amount)
        {
            player2.Money = player1.Money + amount;
            return Ok(player2);
        }


    }
}
