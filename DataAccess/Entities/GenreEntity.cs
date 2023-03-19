using Core.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.DataAccess.Entities
{
    [Table( "Genre" )]
    public class GenreEntity
    {
        [Key][Required] public int GenreId { get; set; }

        [Required] public string GenreName { get; set; }
    }
}
