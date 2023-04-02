using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.DataAccess.Entities
{
    [Table( "FilmRole" )]
    public class FilmRoleEntity
    {
        [Key][Required] public int FilmRoleId { get; set; }
        [Required] public string FilmRoleName { get; set; }
        public string Description { get; set; }
    }
}
