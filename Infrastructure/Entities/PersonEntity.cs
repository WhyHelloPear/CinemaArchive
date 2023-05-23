using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.DataAccess.Entities
{
    [Table( "Person" )]
    public class PersonEntity
    {
        [Key][Required] public int PersonId { get; set; }
        [Required][MaxLength( 60 )] public string FirstName { get; set; }
        [Required][MaxLength( 60 )] public string LastName { get; set; }
        [Required] public DateTime DateOfBirth { get; set; }
    }
}
