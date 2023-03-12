using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class FilmPersonLink
    {
        [Key][ForeignKey("FilmId")] public int FilmId { get; set; }
        [Key][ForeignKey("PersonId")] public int PersonId { get; set; }
        [Key][ForeignKey("PositionId")] public int PositionId { get; set; }
    }
}