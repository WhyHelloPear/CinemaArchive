using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Models
{
    public class FilmRoleDto
    {
        [Key][Required] public int FilmRoleId { get; set; }
        [Required] public string FilmRoleName { get; set; }
        [Required] public string Description { get; set; }
    }
}
