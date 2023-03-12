using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Position
    {
        [Key] public int PositionId { get; set; }
        [Required] public string PositionTitle { get; set; }
    }
}
