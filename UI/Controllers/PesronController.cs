using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UI.ViewModels;

namespace UI.Controllers
{
    [Route( "[controller]" )]
    [ApiController]
    public class PesronController : ControllerBase
    {
        private readonly IMapper _mapper;

        public PesronController( IMapper mapper )
        {
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetPeople")]
        public async Task<ActionResult<PersonViewModel>> GetPeople()
        {
            return Ok( new { } );
        }
    }
}
