using AutoMapper;
using Core.Domain.Contracts;
using Core.Domain.Models;

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

        public async Task<List<FilmRoleDto>> GetFilmRoles()
        {
            List<FilmRole> filmRoles = await _filmRoleRepository.GetFilmRoles();

            return _mapper.Map<List<FilmRoleDto>>(filmRoles );
        }
    }
}
