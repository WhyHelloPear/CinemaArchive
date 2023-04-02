using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Domain.Contracts;
using Core.Domain.Models;
using Infrastructure.DataAccess.Contexts;
using Infrastructure.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repositories
{
    public class FilmRoleRepository : IFilmRoleRepository
    {
        private IMapper _mapper;
        private CinemaArchiveDbContext _dbContext;

        public FilmRoleRepository( CinemaArchiveDbContext dbContext, IMapper mapper )
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<int> CreateFilmRole( FilmRole filmRole )
        {
            FilmRoleEntity newEntity = _mapper.Map<FilmRoleEntity>( filmRole );

            _dbContext.FilmRoleEntities.Add( newEntity );

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<List<FilmRole>> GetFilmRoles()
        {
            return await _dbContext.FilmRoleEntities
                .ProjectTo<FilmRole>( _mapper.ConfigurationProvider )
                .ToListAsync();
        }
    }
}
