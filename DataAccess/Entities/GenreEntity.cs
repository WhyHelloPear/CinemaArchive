namespace Infrastructure.DataAccess.Entities
{
    public class GenreEntity
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public IEnumerable<FilmGenreLinkEntity> FilmGenreLinks { get; set; } = Enumerable.Empty<FilmGenreLinkEntity>();
    }
}
