using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Models
{
    public class Person
    {
        [Key][Required] public int PersonId { get; set; }
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public DateTime DateOfBirth { get; set; }
    }
}
