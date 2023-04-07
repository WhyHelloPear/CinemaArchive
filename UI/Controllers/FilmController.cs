using AutoMapper;
using Core.Application.DTOs;
using Core.Application.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UI.ViewModels;

namespace UI.Controllers
{
    [Route( "[controller]" )]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFilmService _filmService;

        public FilmController( IFilmService filmService, IMapper mapper )
        {
            _filmService = filmService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route( "GetFilms" )]
        public async Task<ActionResult<FilmViewModel>> GetFilms()
        {
            var films = await _filmService.GetFilms();

            List<FilmViewModel> value = _mapper.Map<List<FilmViewModel>>( films );

            return base.Ok( value );
        }

        [HttpGet]
        [Route( "GetFilm" )]
        public async Task<ActionResult<FilmViewModel>> GetFilm(int id)
        {
            FilmDto film = await _filmService.GetFilm( id );

            FilmViewModel value = _mapper.Map<FilmViewModel>( film );
            return base.Ok( value );
        }

        [HttpGet]
        [Route( "GetFilmCount" )]
        public async Task<ActionResult<int>> GetFilmCount()
        {
            return Ok( await _filmService.GetFilmCount() );
        }

        [HttpPost]
        [Route( "CreateFilm" )]
        public async Task<IActionResult> CreateFilmAsync( [FromBody] FilmViewModel film )
        {
            FilmDto hey = _mapper.Map<FilmDto>( film );
            Result test = await _filmService.CreateFilm( hey );

            return test.IsSuccess ? Ok( new { isSuccss = test.IsSuccess } ) : BadRequest( new { test.IsSuccess, test.Errors.First().Message } );
        }

        [HttpPost]
        [Route( "UpdateFilm" )]
        public async Task<IActionResult> UpdateFilmAsync( [FromBody] FilmViewModel film )
        {
            FilmDto hey = _mapper.Map<FilmDto>( film );
            Result test = await _filmService.UpdateFilm( hey );

            return test.IsSuccess ? Ok( new { isSuccss = test.IsSuccess } ) : BadRequest( new { test.IsSuccess, test.Errors.First().Message } );
        }

        [HttpPost]
        [Route( "DeleteFilm" )]
        public async Task<IActionResult> DeleteFilmAsync( [FromBody] int filmId )
        {
            Result test = await _filmService.DeleteFilm( filmId );

            return test.IsSuccess ? Ok( new { isSuccss = test.IsSuccess } ) : BadRequest( new { test.IsSuccess, test.Errors.First().Message } );
        }
    }
}
