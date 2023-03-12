using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.DataAccess.Entities
{
    [Table("FilmGenreLink")]
    public class FilmGenreLinkEntity
    {
        [Key] public int FilmId { get; set; }
        [Key] public int GenreId { get; set; }
        public FilmEntity Film { get; set; }
        public GenreEntity Genre { get; set; }
    }
}
