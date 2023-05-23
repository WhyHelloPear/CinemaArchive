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

        public async Task<int> DeleteFilmRole( int filmRoleId )
        {
            FilmRoleEntity existingFilmRole = _dbContext.FilmRoleEntities.FirstOrDefault( fr => fr.FilmRoleId == filmRoleId );

            if( existingFilmRole == null ) {
                return 0;
            }

            _dbContext.FilmRoleEntities.Remove( existingFilmRole );

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<List<FilmRole>> GetFilmRoles()
        {
            return await _dbContext.FilmRoleEntities
                .ProjectTo<FilmRole>( _mapper.ConfigurationProvider )
                .ToListAsync();
        }

        public async Task<int> UpdateFilmRole( FilmRole roleToUpdate )
        {
            FilmRoleEntity? existingFilmRole = _dbContext.FilmRoleEntities.FirstOrDefault( fr => fr.FilmRoleId == roleToUpdate.FilmRoleId );

            if( existingFilmRole == null ) {
                return 0;
            }

            existingFilmRole.FilmRoleName = roleToUpdate.FilmRoleName;
            existingFilmRole.Description = roleToUpdate.Description;

            return await _dbContext.SaveChangesAsync();
        }
    }
}
