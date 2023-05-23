using Core.Domain.Models;

namespace Core.Domain.Contracts
{
    public interface IFilmRoleRepository
    {
        Task<int> CreateFilmRole( FilmRole filmRole );
        Task<int> DeleteFilmRole( int filmRoleId );
        Task<List<FilmRole>> GetFilmRoles();
        Task<int> UpdateFilmRole( FilmRole roleToUpdate );
    }
}
