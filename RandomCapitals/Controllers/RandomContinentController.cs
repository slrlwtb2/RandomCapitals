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
        [HttpPost]
        public IActionResult CreatePlayer(CreatePlayerRequest model)
        {
            if (ModelState.IsValid)
            {
                player1.Name = model.Player1;
                player1.Continent = _randomContinent.GenerateRandomCoordinates();

                player2.Name = model.Player2;
                player2.Continent = _randomContinent.GenerateRandomCoordinates();
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
