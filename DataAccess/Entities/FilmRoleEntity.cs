using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.DataAccess.Entities
{
    [Table("FilmRole")]
    public class FilmRoleEntity
    {
        [Key][Required] public int RoleId { get; set; }
        [Required] public string FilmRoleTitle { get; set; }
    }
}
