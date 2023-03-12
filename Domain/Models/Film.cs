using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Film
    {
        [Key] public int FilmId { get; set; }
        [Required] public string FilmTitle { get; set; }
        [Required] public DateTime ReleaseDate { get; set; }
        public decimal GrossRevenue { get; set; }
    }
}
