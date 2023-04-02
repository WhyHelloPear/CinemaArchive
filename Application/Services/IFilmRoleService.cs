using Core.Domain.Models;
using FluentResults;

namespace Core.Application.Services
{
    public interface IFilmRoleService
    {
        Task<Result> CreateFilmRole( FilmRoleDto filmRoleDto );
        Task<List<FilmRoleDto>> GetFilmRoles();
    }
}
