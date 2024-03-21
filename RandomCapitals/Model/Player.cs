using System.ComponentModel.DataAnnotations;

namespace RandomContinent.Model
{
    public class Player
    {
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Continent is Required")]
        public int[] Continent { get; set; }
        public int Money { get; set; } = 1000;
    }
}
