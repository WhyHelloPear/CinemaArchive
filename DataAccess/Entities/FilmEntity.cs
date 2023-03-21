using Core.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.DataAccess.Entities
{
    [Table( "Film" )]
    public class FilmEntity
    {
        [Key][Required] public int FilmId { get; set; }
        [Required] public string FilmTitle { get; set; }
        [Required] public DateTime ReleaseDate { get; set; }
        public ICollection<FilmGenreLinkEntity> FilmGenreLinks { get; set; }
    }
}
