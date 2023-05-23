using Core.Domain.Models;
using FluentResults;

namespace Core.Domain.Services
{
    public interface IFilmRoleService
    {
        Task<Result> CreateFilmRole( FilmRole filmRoleDto );
        Task<Result> DeleteFilmRole( int filmRoleId );
        Task<List<FilmRole>> GetFilmRoles();
        Task<Result> UpdateFilmRole( FilmRole filmRoleDto );
    }
}
