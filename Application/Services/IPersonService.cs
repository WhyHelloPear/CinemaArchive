using Core.Application.DTOs;
using FluentResults;

namespace Core.Application.Services
{
    public interface IPersonService
    {
        Task<List<PersonDto>> GetPeople();
        Task<Result> CreatePerson(PersonDto person);
    }
}
