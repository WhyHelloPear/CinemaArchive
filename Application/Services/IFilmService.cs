﻿using Core.Application.DTOs;

namespace Core.Application.Services
{
    public interface IFilmService
    {
        Task<List<FilmDto>> GetFilms();
    }
}
