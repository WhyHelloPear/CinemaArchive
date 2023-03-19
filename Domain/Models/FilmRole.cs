using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Models
{
    public class FilmRole
    {
        [Key][Required] public int FilmRoleId { get; set; }
        [Required] public string FilmRoleTitle { get; set; }
    }
}
