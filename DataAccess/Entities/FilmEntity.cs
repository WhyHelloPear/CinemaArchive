using Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.DataAccess.Entities
{
    [Table("Film")]
    public class FilmEntity
    {
        [Key]public int FilmId { get; set; }
        public string FilmTitle { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
