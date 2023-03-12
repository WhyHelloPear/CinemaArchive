using System.ComponentModel.DataAnnotations;

namespace Core.Domain.Models
{
    public class Person
    {
        [Key] public int PersonId { get; set; }
        [Required] public string PersonName { get; set; }
    }
}
