using RandomCapitals.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace RandomContinent.Model
{
    public class Player
    {
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Continent is Required")]
        public int[] Continent { get; set; }
        public int Money { get; set; } = 1000;
        public List<OwnCoordinate> MyCoordinates { get; set; } = new List<OwnCoordinate>();

        public List<int[]> FindAdjacentCoordinates()
        {
            var adjacentCoordinates = new List<int[]>();

            foreach (var ownCoordinate in MyCoordinates)
            {
                int x = ownCoordinate.Coordinates[0];
                int y = ownCoordinate.Coordinates[1];

                // Directions: up, down, left, right, northeast, southwest
                if (x % 2 == 0)
                {
                    int[,] directions = { { 0, -1 }, { 0, 1 }, { -1, 0 }, { -1, 1 }, { 1, 0 }, { -1, -1 } };
                    adjacentCoordinates.AddRange(Enumerable.Range(0, directions.GetLength(0))
                        .Select(index =>
                        {
                            int newX = x + directions[index, 0];
                            int newY = y + directions[index, 1];
                            return new int[] { newX, newY };
                        })
                        .Where(coord => coord[0] >= 0 && coord[0] < 18 && coord[1] >= 0 && coord[1] < 9)); 
                }
                else
                {
                    int[,] directions = { { 0, -1 }, { 0, 1 }, { -1, -1 }, { -1, 0 }, { -1, 1 }, { 1, 0 } };
                    adjacentCoordinates.AddRange(Enumerable.Range(0, directions.GetLength(0))
                        .Select(index =>
                        {
                            int newX = x + directions[index, 0];
                            int newY = y + directions[index, 1];
                            return new int[] { newX, newY };
                        })
                        .Where(coord => coord[0] >= 0 && coord[0] < 18 && coord[1] >= 0 && coord[1] < 9));
                }
            }

            return adjacentCoordinates;
        }



    }
}
