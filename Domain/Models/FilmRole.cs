using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Models
{
    public class FilmRole
    {
        [Key][Required] public int FilmRoleId { get; set; }
        [Required] public string FilmRoleName { get; set; }
        public string Description { get; set; }
    }
}
