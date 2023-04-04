using AutoMapper;
using Core.Application.DTOs;
using Core.Domain.Models;
using Domain.Contracts;
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

        public async Task<Result> CreatePerson( PersonDto person )
        {
            Person personToCreate = _mapper.Map<Person>( person );

            int numChanges = await _personRepository.CreatePerson( personToCreate );

            return numChanges > 0 ? Result.Ok() : Result.Fail( "Screw you" );
        }

        public async Task<Result> DeletePerson( int personId )
        {
            int numChanges = await _personRepository.DeletePerson( personId );

            return numChanges > 0 ? Result.Ok() : Result.Fail( "Unable to delete person" );
        }

        public async Task<List<PersonDto>> GetPeople()
        {
            var people = await _personRepository.GetPeople();

            return _mapper.Map<List<PersonDto>>( people );
        }

        public async Task<Result> UpdatePerson( PersonDto personToUpdate )
        {
            Person person = _mapper.Map<Person>( personToUpdate );
            int numChangesMade = await _personRepository.UpdatePerson( person );

            return numChangesMade > 0 ? Result.Ok() : Result.Fail( "No changes saved." );
        }
    }
}
