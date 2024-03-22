﻿using Microsoft.AspNetCore.Mvc;
using RandomCapitals.Model;
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
        [HttpGet("Getadjacen")]
        public IActionResult GetAdjacenRegion(string player)
        {
            if (player == "Player 1")
            {
                var listOfRegion = player1.FindAdjacentCoordinates();
                return Ok(listOfRegion);
            }
            else
            {
                var listOfRegion = player2.FindAdjacentCoordinates();
                return Ok(listOfRegion);
            }

        }
        [HttpPost]
        public IActionResult CreatePlayer(CreatePlayerRequest model)
        {
            if (ModelState.IsValid)
            {
                player1.Name = model.Player1;
                player1.Continent = _randomContinent.GenerateRandomCoordinates();
                OwnCoordinate mainCity1 = new OwnCoordinate()
                {
                    Power = 1,
                    Coordinates = player1.Continent
                };
                player1.MyCoordinates.Add(mainCity1);

                player2.Name = model.Player2;
                player2.Continent = _randomContinent.GenerateRandomCoordinates();
                OwnCoordinate mainCity2 = new OwnCoordinate()
                {
                    Power = 1,
                    Coordinates = player2.Continent
                };
                player2.MyCoordinates.Add(mainCity2);
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
        [HttpPost("BuyRegion")]
        public IActionResult BuyRegion(string player, int[] coordinate,int budget)
        {
            if (player == "Player 1")
            {
                var regionList = _randomContinent.GetOwnRegion(player1);
                if (budget < 10 || budget > player1.Money)
                    return BadRequest();

                if (regionList.Any(x => x.Coordinates.SequenceEqual(coordinate)))
                    return BadRequest("You already own that region");

                List<int[]> adjacentCoordinates = player1.FindAdjacentCoordinates();
                if (!adjacentCoordinates.Any(c => c.SequenceEqual(coordinate)))
                    return BadRequest("You can only buy adjacent regions");

                var buyRegion = new OwnCoordinate()
                {
                    Power = budget,
                    Coordinates = coordinate
                };
                player1.Money -= budget;
                player1.MyCoordinates.Add(buyRegion);

                return Ok(player1);
            }
            else
            {
                var regionList = _randomContinent.GetOwnRegion(player2);
                if (budget < 10 || budget > player2.Money)
                    return BadRequest();

                if (regionList.Any(x => x.Coordinates.SequenceEqual(coordinate)))
                    return BadRequest("You already own that region");

                List<int[]> adjacentCoordinates = player2.FindAdjacentCoordinates();
                if (!adjacentCoordinates.Any(c => c.SequenceEqual(coordinate)))
                    return BadRequest("You can only buy adjacent regions");

                var buyRegion = new OwnCoordinate()
                {
                    Power = budget,
                    Coordinates = coordinate
                };
                player2.Money -= budget;
                player2.MyCoordinates.Add(buyRegion);

                return Ok(player2);
            }
        }


    }
}
