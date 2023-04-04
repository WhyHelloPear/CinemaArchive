using AutoMapper;
using Core.Domain.Contracts;
using Core.Domain.Models;
using FluentResults;

namespace Core.Application.Services
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

        public async Task<Result> CreateFilmRole( FilmRoleDto filmRoleDto )
        {
            FilmRole filmRole = _mapper.Map<FilmRole>( filmRoleDto );
            int numChanges = await _filmRoleRepository.CreateFilmRole( filmRole );

            return numChanges > 0 ? Result.Ok() : Result.Fail( "No changes made" );
        }

        public async Task<Result> DeleteFilmRole( int filmRoleId )
        {
            int numChanges = await _filmRoleRepository.DeleteFilmRole( filmRoleId );

            return Result.FailIf( numChanges == 0, "No Changes Made" );
        }

        public async Task<List<FilmRoleDto>> GetFilmRoles()
        {
            List<FilmRole> filmRoles = await _filmRoleRepository.GetFilmRoles();

            return _mapper.Map<List<FilmRoleDto>>( filmRoles );
        }

        public async Task<Result> UpdateFilmRole( FilmRoleDto filmRoleDto )
        {
            FilmRole roleToUpdate = _mapper.Map<FilmRole>( filmRoleDto );
            int numChangesMade = await _filmRoleRepository.UpdateFilmRole( roleToUpdate );

            return Result.OkIf( numChangesMade > 0, "No changes made" );
        }
    }
}
