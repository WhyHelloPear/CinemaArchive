using AutoMapper;
using Core.Domain.Contracts;
using Core.Domain.Models;
using FluentResults;

namespace Core.Domain.Services
{
    public class FilmRoleService : IFilmRoleService
    {
        private IMapper _mapper;
        private IFilmRoleRepository _filmRoleRepository;

        public FilmRoleService( IFilmRoleRepository filmRoleRepository, IMapper mapper )
        {
            _filmRoleRepository = filmRoleRepository;
            _mapper = mapper;
        }

        public async Task<Result> CreateFilmRole( FilmRole filmRole )
        {
            int numChanges = await _filmRoleRepository.CreateFilmRole( filmRole );

            return numChanges > 0 ? Result.Ok() : Result.Fail( "No changes made" );
        }

        public async Task<Result> DeleteFilmRole( int filmRoleId )
        {
            int numChanges = await _filmRoleRepository.DeleteFilmRole( filmRoleId );

            return Result.FailIf( numChanges == 0, "No Changes Made" );
        }

        public async Task<List<FilmRole>> GetFilmRoles()
        {
            return await _filmRoleRepository.GetFilmRoles();
        }

        public async Task<Result> UpdateFilmRole( FilmRole roleToUpdate )
        {
            int numChangesMade = await _filmRoleRepository.UpdateFilmRole( roleToUpdate );

            return Result.OkIf( numChangesMade > 0, "No changes made" );
        }
    }
}
