using System.ComponentModel.DataAnnotations;

namespace Core.Application.DTOs
{
    public class FilmRoleDto
    {
        [Key][Required] public int FilmRoleId { get; set; }
        [Required] public string FilmRoleName { get; set; }
        public string Description { get; set; }
    }
}
