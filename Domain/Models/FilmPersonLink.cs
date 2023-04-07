namespace Core.Domain.Models
{
    public class FilmPersonLink
    {
        public int FilmPersonLinkId { get; set; }
        public Person RelatedPerson { get; set; }
        public Film RelatedFilm { get; set; }
        public FilmRole RelatedFilmRole { get; set; }
    }
}