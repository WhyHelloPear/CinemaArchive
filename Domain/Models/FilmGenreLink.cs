namespace Core.Domain.Models
{
    public class FilmGenreLink
    {
        public FilmGenreLink( int filmId, int genreId )
        {
            FilmId = filmId;
            GenreId = genreId;
        }

        public int FilmId { get; set; }
        public int GenreId { get; set; }
    }
}