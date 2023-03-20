﻿using AutoMapper;
using Core.Application.DTOs;
using Core.Application.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using UI.ViewModels;

namespace UI.Controllers
{
    [Route( "[controller]" )]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFilmService _filmService;

        public GenreController( IFilmService filmService, IMapper mapper )
        {
            _filmService = filmService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route( "GetGenres" )]
        public async Task<ActionResult<GenreViewModel>> GetGenres()
        {
            return Ok( await _filmService.GetGenres() );
        }

        [HttpGet]
        [Route( "GetGenreCount" )]
        public async Task<ActionResult<int>> GetGenreCount()
        {
            return Ok( await _filmService.GetGenreCount() );
        }

        [HttpPost]
        [Route( "CreateGenre" )]
        public async Task<IActionResult> SaveGenreAsync( [FromBody] GenreViewModel genreToSave )
        {
            GenreDto hey = _mapper.Map<GenreDto>( genreToSave );
            Result test = await _filmService.CreateGenre( hey );

            return test.IsSuccess ? Ok( new { isSuccss = test.IsSuccess } ) : BadRequest( new { test.IsSuccess, test.Errors.First().Message } );
        }

        [HttpPost]
        [Route( "UpdateGenre" )]
        public async Task<IActionResult> UpdateGenreAsync( [FromBody] GenreViewModel genreToUpdate )
        {
            GenreDto hey = _mapper.Map<GenreDto>( genreToUpdate );
            Result test = await _filmService.UpdateGenre( hey );

            return test.IsSuccess ? Ok( new { isSuccss = test.IsSuccess } ) : BadRequest( new { test.IsSuccess, test.Errors.First().Message } );
        }

        [HttpPost]
        [Route( "DeleteGenre" )]
        public async Task<IActionResult> DeleteGenreAsync( [FromBody] int genreId )
        {
            Result test = await _filmService.DeleteGenre( genreId );

            return test.IsSuccess ? Ok( new { isSuccss = test.IsSuccess } ) : BadRequest( new { test.IsSuccess, test.Errors.First().Message } );
        }
    }
}