using System.ComponentModel.DataAnnotations;

namespace RandomCapitals.ModelRequest
{
    public class CreatePlayerRequest
    {
        [Required(ErrorMessage = "Name1 is Required")]
        public required string Player1 { get; set; }
        [Required(ErrorMessage = "Continent1 is Required")]
        public required int[] Player1Continent { get; set; }
        [Required(ErrorMessage = "Name2 is Required")]
        public required string Player2 { get; set; }
        [Required(ErrorMessage = "Continent2 is Required")]
        public required int[] Player2Continent { get; set; }


    }
}
