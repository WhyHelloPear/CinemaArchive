using AutoMapper;
using Core.Domain.Contracts;
using Core.Domain.Models;
using FluentResults;

namespace Core.Application.Services
{
    public class PersonService : IPersonService
    {
        private IMapper _mapper;
        private IPersonRepository _personRepository;

        public PersonService( IPersonRepository personRepository, IMapper mapper )
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<Result> CreatePerson( Person personToCreate )
        {
            int numChanges = await _personRepository.CreatePerson( personToCreate );

            return numChanges > 0 ? Result.Ok() : Result.Fail( "Screw you" );
        }

        public async Task<Result> DeletePerson( int personId )
        {
            int numChanges = await _personRepository.DeletePerson( personId );

            return numChanges > 0 ? Result.Ok() : Result.Fail( "Unable to delete person" );
        }

        public async Task<List<Person>> GetPeople()
        {
            return await _personRepository.GetPeople();
        }

        public async Task<Result> UpdatePerson( Person personToUpdate )
        {
            int numChangesMade = await _personRepository.UpdatePerson( personToUpdate );

            return numChangesMade > 0 ? Result.Ok() : Result.Fail( "No changes saved." );
        }
    }
}
