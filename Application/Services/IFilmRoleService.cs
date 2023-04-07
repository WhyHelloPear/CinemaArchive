using Core.Application.DTOs;
using FluentResults;

namespace Core.Application.Services
{
    public interface IFilmRoleService
    {
        Task<Result> CreateFilmRole( FilmRoleDto filmRoleDto );
        Task<Result> DeleteFilmRole( int filmRoleId );
        Task<List<FilmRoleDto>> GetFilmRoles();
        Task<Result> UpdateFilmRole( FilmRoleDto filmRoleDto );
    }
}
