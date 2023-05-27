using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Domain.Contracts;
using Core.Domain.Models;
using Infrastructure.DataAccess.Contexts;
using Infrastructure.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IMapper _mapper;
        private readonly CinemaArchiveDbContext _dbContext;

        public PersonRepository( CinemaArchiveDbContext dbContext, IMapper mapper )
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<int> CreatePerson( Person person )
        {
            PersonEntity newPerson = _mapper.Map<PersonEntity>( person );

            _dbContext.PersonEntities.Add( newPerson );

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeletePerson( int personId )
        {
            PersonEntity targetPerson = _dbContext.PersonEntities
                .FirstOrDefault( p => p.PersonId == personId );

            if( targetPerson == null ) {
                return 0;
            }

            _dbContext.Remove( targetPerson );

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> GetNumPeople()
        {
            return await _dbContext.PersonEntities.CountAsync();
        }

        public async Task<List<Person>> GetPeople()
        {
            return await _dbContext.PersonEntities
                .ProjectTo<Person>( _mapper.ConfigurationProvider )
                .ToListAsync();
        }

        public async Task<int> UpdatePerson( Person person )
        {
            PersonEntity existingPerson = _dbContext.PersonEntities
                .FirstOrDefault( p => p.PersonId == person.PersonId );

            if( existingPerson == null ) {
                return 0;
            }

            existingPerson.FirstName = person.FirstName;
            existingPerson.LastName = person.LastName;
            existingPerson.DateOfBirth = person.DateOfBirth;

            return await _dbContext.SaveChangesAsync();
        }


    }
}
