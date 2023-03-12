using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class FilmGenreLink
    {
        [Key][ForeignKey("FilmId")] public int FilmId { get; set; }
        [Key][ForeignKey("GenreId")] public int GenreId { get; set; }
    }
}