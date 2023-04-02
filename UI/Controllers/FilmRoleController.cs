using AutoMapper;
using Core.Application.Services;
using Core.Domain.Models;
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

        [HttpGet]
        [Route( "GetFilmRoles" )]
        public async Task<ActionResult<FilmRoleViewModel>> GetFilmRoles()
        {
            List<FilmRoleDto> people = await _filmRoleService.GetFilmRoles();

            return Ok( _mapper.Map<List<FilmRoleViewModel>>( people ) );
        }
    }
}
