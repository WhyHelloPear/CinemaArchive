using Core.Application.DTOs;
using Core.Application.Services;
using Geocoding;
using Microsoft.AspNetCore.Mvc;

namespace TBD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IFilmService _filmService;

        public HomeController(IFilmService filmService)
        {
            _filmService = filmService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmDto>>> GetMyData()
        {
            var myData = await _filmService.GetFilms();

            return Ok(myData);
        }
    }
}
