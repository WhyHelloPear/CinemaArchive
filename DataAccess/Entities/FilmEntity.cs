using Core.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.DataAccess.Entities
{
    [Table( "Film" )]
    public class FilmEntity : IEntity<Film>
    {
        [Key][Required] public int FilmId { get; set; }
        [Required] public string FilmTitle { get; set; }
        [Required] public DateTime ReleaseDate { get; set; }

        public bool IsMatching( Film filmToSave )
        {
            return (
                ( filmToSave.FilmId > 0 && filmToSave.FilmId == FilmId ) ||
                ( filmToSave.FilmTitle == FilmTitle && filmToSave.ReleaseDate == ReleaseDate )
            );
        }

        public bool IsValidUpdate( Film entity )
        {
            throw new NotImplementedException();
        }
    }
}
