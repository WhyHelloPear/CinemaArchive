using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Models {
    public class Genre {
        [Key] public int GenreId { get; set; }
        [Required] public string GenreName { get; set; }
    }
}
