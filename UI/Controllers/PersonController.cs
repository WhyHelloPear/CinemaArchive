using AutoMapper;
using Core.Domain.Models;
using Core.Domain.Services;
using FluentResults;
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
        public async Task<ActionResult<PersonViewModel>> CreatePerson( [FromBody] PersonViewModel newPerson )
        {
            Person person = _mapper.Map<Person>( newPerson );

            var result = await _personService.CreatePerson( person );
            return Ok();
        }

        [HttpPost]
        [Route( "UpdatePerson" )]
        public async Task<ActionResult<PersonViewModel>> UpdatePerson( [FromBody] PersonViewModel personToUpdate )
        {
            Person hey = _mapper.Map<Person>( personToUpdate );
            Result result = await _personService.UpdatePerson( hey );

            return Ok();
        }

        [HttpPost]
        [Route( "DeletePerson" )]
        public async Task<ActionResult<PersonViewModel>> DeletePerson( [FromBody] int personId )
        {
            Result result = await _personService.DeletePerson( personId );

            return Ok();
        }


    }
}
