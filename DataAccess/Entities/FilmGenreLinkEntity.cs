using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.DataAccess.Entities
{
    [Table( "FilmGenreLink" )]
    public class FilmGenreLinkEntity
    {
        public FilmGenreLinkEntity( int filmId, int genreId )
        {
            FilmId = filmId;
            GenreId = genreId;
        }

        [Key][Required] public int FilmId { get; set; }
        [Key][Required] public int GenreId { get; set; }
        public FilmEntity Film { get; set; }
        public GenreEntity Genre { get; set; }
    }
}
