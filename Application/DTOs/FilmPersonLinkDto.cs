using System.ComponentModel.DataAnnotations;

namespace Core.Application.DTOs
{
    public class FilmPersonLinkDto
    {
        [Required] public int FilmPersonLinkId { get; set; }
        public PersonDto Person { get; set; }
        public FilmDto Film { get; set; }
        public FilmRoleDto FilmRole { get; set; }
    }
}