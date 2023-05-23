using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.DataAccess.Entities
{
    public class FilmPersonLinkViewModel
    {
        public int FilmPersonLinkId { get; set; }
        public int PersonId { get; set; }
        public int FilmRoleId { get; set; }
        public string PersonFirstName { get; set; }
        public string PersonLastName { get; set; }
        public string FilmRoleName { get; set; }
    }
}
