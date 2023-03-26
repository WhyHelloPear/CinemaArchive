﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Domain.Models;
using Domain.Contracts;
using Infrastructure.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IMapper _mapper;
        private readonly CinemaArchiveDbContext _dbContext;

        public PersonRepository( CinemaArchiveDbContext dbContext, IMapper mapper )
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<int> GetNumPeople()
        {
            return await _dbContext.PersonEntities.CountAsync();
        }

        public async Task<List<Person>> GetPeople()
        {
            return await _dbContext.PersonEntities
                .ProjectTo<Person>( _mapper.ConfigurationProvider )
                .ToListAsync();
        }
    }
}
