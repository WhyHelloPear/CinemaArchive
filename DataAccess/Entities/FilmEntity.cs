using Core.Domain.Models;

namespace Infrastructure.DataAccess.Entities
{
    public class FilmEntity
    {
        public int FilmId { get; set; }
        public string FilmTitle { get; set; }
        public DateTime ReleaseDate { get; set; }
        public IEnumerable<FilmGenreLink> FilmGenreLinks { get; set; } = Enumerable.Empty<FilmGenreLink>();
    }
}
