using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.DataAccess.Entities
{
    [Table("Genre")]
    public class GenreEntity
    {
        [Key]public int GenreId { get; set; }
        public string GenreName { get; set; }
    }
}
