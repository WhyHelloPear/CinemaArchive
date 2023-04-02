using Core.Domain.Models;

namespace Core.Application.Services
{
    public interface IFilmRoleService
    {
        Task<List<FilmRoleDto>> GetFilmRoles();
    }
}
