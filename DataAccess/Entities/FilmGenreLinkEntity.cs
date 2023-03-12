namespace Infrastructure.DataAccess.Entities
{
    public class FilmGenreLinkEntity
    {
        public int FilmId { get; set; }
        public FilmEntity Film { get; set; }
        public int GenreId { get; set; }
        public GenreEntity Genre { get; set; }
    }
}
