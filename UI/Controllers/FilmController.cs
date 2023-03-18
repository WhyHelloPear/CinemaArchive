﻿using AutoMapper;
using Core.Application.DTOs;
using Core.Application.Services;
using Core.Domain.Models;
using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UI.ViewModels;

namespace UI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFilmService _filmService;

        public FilmController(IFilmService filmService, IMapper mapper)
        {
            _filmService = filmService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetFilms")]
        public async Task<ActionResult<FilmViewModel>> GetFilms()
        {
            var films = await _filmService.GetFilms();

            return Ok(_mapper.Map<List<FilmViewModel>>(films));
        }

        [HttpGet]
        [Route("GetFilmCount")]
        public async Task<ActionResult<int>> GetFilmCount()
        {
            return Ok(await _filmService.GetFilmCount());
        }

        [HttpGet]
        [Route("GetGenreCount")]
        public async Task<ActionResult<int>> GetGenreCount()
        {
            return Ok(await _filmService.GetGenreCount());
        }

        [HttpPost]
        [Route("SaveFilm")]
        public async Task<IActionResult> SaveFilmAsync([FromBody] FilmViewModel film)
        {
            FilmDto hey = _mapper.Map<FilmDto>(film);
            Result test = await _filmService.SaveFilm(hey);

            return test.IsSuccess ? Ok() : BadRequest( test.Errors.First().Message);
        }

    }
}
