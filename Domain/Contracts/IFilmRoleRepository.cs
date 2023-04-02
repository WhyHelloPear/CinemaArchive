using Core.Domain.Models;

namespace Core.Domain.Contracts
{
    public interface IFilmRoleRepository
    {
        Task<List<FilmRole>> GetFilmRoles();
    }
}
