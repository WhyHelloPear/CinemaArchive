using AutoMapper;
using Core.Application.Services;
using Core.Domain.Models;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UI.ViewModels;

namespace UI.Controllers
{
    [Route( "[controller]" )]
    [ApiController]
    public class FilmRoleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFilmRoleService _filmRoleService;

        public FilmRoleController( IFilmRoleService filmRoleService, IMapper mapper )
        {
            _filmRoleService = filmRoleService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route( "GetFilmRoles" )]
        public async Task<ActionResult<FilmRoleViewModel>> GetFilmRoles()
        {
            List<FilmRoleDto> people = await _filmRoleService.GetFilmRoles();

            return Ok( _mapper.Map<List<FilmRoleViewModel>>( people ) );
        }

        [HttpPost]
        [Route( "CreateFilmRole" )]
        public async Task<ActionResult<FilmRoleViewModel>> CreateFilmRole( [FromBody] FilmRoleViewModel newFilmRole )
        {
            FilmRoleDto filmRoleDto = _mapper.Map<FilmRoleDto>( newFilmRole );

            Result result = await _filmRoleService.CreateFilmRole( filmRoleDto );

            return Ok();
        }

        [HttpPost]
        [Route( "UpdateFilmRole" )]
        public async Task<ActionResult<FilmRoleViewModel>> UpdateFilmRole( [FromBody] FilmRoleViewModel newFilmRole )
        {
            FilmRoleDto filmRoleDto = _mapper.Map<FilmRoleDto>( newFilmRole );

            Result result = await _filmRoleService.UpdateFilmRole( filmRoleDto );

            return Ok();
        }

        [HttpPost]
        [Route( "DeleteFilmRole" )]
        public async Task<ActionResult<FilmRoleViewModel>> CreateFilmRole( [FromBody] int filmRoleId )
        {
            Result result = await _filmRoleService.DeleteFilmRole( filmRoleId );

            return Ok();
        }
    }
}
