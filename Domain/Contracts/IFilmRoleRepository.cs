using Core.Domain.Models;

namespace Core.Domain.Contracts
{
    public interface IFilmRoleRepository
    {
        Task<int> CreateFilmRole( FilmRole filmRole );
        Task<List<FilmRole>> GetFilmRoles();
    }
}
