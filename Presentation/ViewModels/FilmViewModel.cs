using Infrastructure.DataAccess.Entities;

namespace UI.ViewModels
{
    public class FilmViewModel
    {
        public int FilmId { get; set; }
        public string FilmTitle { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<GenreViewModel> GenreList { get; set; } = new List<GenreViewModel>();
        public List<FilmPersonLinkViewModel> FilmPersonLinks { get; set; } = new List<FilmPersonLinkViewModel>();
    }
}
