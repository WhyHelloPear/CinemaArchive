using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Genre
    {
        [Key] public int GenreId { get; set; }
        [Required] public string GenreName { get; set; }
    }
}
