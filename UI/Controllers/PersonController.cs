using AutoMapper;
using Core.Application.DTOs;
using Core.Application.Services;
using Microsoft.AspNetCore.Mvc;
using UI.ViewModels;

namespace UI.Controllers
{
    [Route( "[controller]" )]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPersonService _personService;

        public PersonController( IMapper mapper, IPersonService personService )
        {
            _mapper = mapper;
            _personService = personService;
        }

        [HttpGet]
        [Route( "GetPeople" )]
        public async Task<ActionResult<PersonViewModel>> GetPeople()
        {
            var people = await _personService.GetPeople();

            return Ok( _mapper.Map<List<PersonViewModel>>( people ) );
        }

        [HttpPost]
        [Route( "CreatePerson" )]
        public async Task<ActionResult<PersonViewModel>> CreatePerson([FromBody] PersonViewModel newPerson)
        {
            PersonDto personDto = _mapper.Map<PersonDto>( newPerson );

            var result = _personService.CreatePerson( personDto );
            return Ok();
        }
    }
}
