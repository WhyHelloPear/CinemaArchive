using AutoMapper;
using Core.Application.DTOs;
using Domain.Contracts;

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

        public async Task<List<PersonDto>> GetPeople()
        {
            var people = await _personRepository.GetPeople();
            
            return _mapper.Map<List<PersonDto>>( people );
        }
    }
}
