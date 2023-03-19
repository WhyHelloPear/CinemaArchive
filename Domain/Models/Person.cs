using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Models
{
    public class Person
    {
        [Key][Required] public int PersonId { get; set; }
        [Required] public string PersonName { get; set; }
    }
}
