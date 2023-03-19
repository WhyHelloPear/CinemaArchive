using Core.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.DataAccess.Entities
{
    [Table( "Genre" )]
    public class GenreEntity : IEntity<Genre>
    {
        [Key][Required] public int GenreId { get; set; }

        [Required] public string GenreName { get; set; }

        public bool IsMatching( Genre entity )
        {
            return (
                entity.GenreId == GenreId ||
                string.Equals( entity.GenreName.ToLower().Trim(), GenreName.ToLower().Trim() )
            );
        }

        public bool IsValidUpdate( Genre genre )
        {
            return (
                string.Equals( genre.GenreName.ToLower().Trim(), GenreName.ToLower().Trim() )
            );
        }
    }
}
