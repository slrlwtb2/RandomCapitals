using System.ComponentModel.DataAnnotations;

namespace RandomCapitals.ModelRequest
{
    public class CreatePlayerRequest
    {
        [Required(ErrorMessage = "Name1 is Required")]
        public required string Player1 { get; set; }
        [Required(ErrorMessage = "Name2 is Required")]
        public required string Player2 { get; set; }


    }
}
