using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.DataAccess.Entities
{
    [Table( "FilmPersonLink" )]
    public class FilmPersonLinkEntity
    {
        [Key][Required] public int FilmId { get; set; }
        [Key][Required] public int PersonId { get; set; }
        [Key][Required] public int FilmRoleId { get; set; }
        public FilmEntity Film { get; set; }
        public PersonEntity Person { get; set; }
        public FilmRoleEntity FilmRole { get; set; }
    }
}
