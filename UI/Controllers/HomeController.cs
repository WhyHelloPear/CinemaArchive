using AutoMapper;
using Core.Application.Services;
using Microsoft.AspNetCore.Mvc;
using UI.ViewModels;

namespace TBD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFilmService _filmService;

        public HomeController(IFilmService filmService, IMapper mapper)
        {
            _filmService = filmService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<FilmViewModel>>> GetMyData()
        {
            var myData = await _filmService.GetFilms();

            return Ok(_mapper.Map<List<FilmViewModel>>(myData));
        }
    }
}
