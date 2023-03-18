using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.DataAccess.Entities {
    [Table( "Person" )]
    public class PersonEntity {
        [Key][Required] public int PersonId { get; set; }
        [Required] public string PersonName { get; set; }
    }
}
