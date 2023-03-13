using AutoMapper;
using Core.Domain.Models;
using Domain.Contracts;
using FluentResults;
using Infrastructure.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Infrastructure.DataAccess.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IMapper _mapper;
        private readonly CinemaArchiveDbContext _dbContext;

        public PersonRepository(CinemaArchiveDbContext dbContext, IMapper mapper )
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public Task<Result<int>> DeletePerson(int personId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<int>> DeletePosition(int positionId)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetNumPeople()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Person>> GetPeople()
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<FilmRole>> GetPositions()
        {
            throw new NotImplementedException();
        }

        public Task<Result<int>> InsertPerson(Person person)
        {
            throw new NotImplementedException();
        }

        public Task<Result<int>> InsertPosition(FilmRole position)
        {
            throw new NotImplementedException();
        }

        public Task<Result<int>> UpdatePerson(Person person)
        {
            throw new NotImplementedException();
        }

        public Task<Result<int>> UpdatePosition(FilmRole position)
        {
            throw new NotImplementedException();
        }
    }
}
