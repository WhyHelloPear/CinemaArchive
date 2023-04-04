using Core.Application.DTOs;
using FluentResults;

namespace Core.Application.Services
{
    public interface IPersonService
    {
        Task<List<PersonDto>> GetPeople();
        Task<Result> CreatePerson( PersonDto person );
        Task<Result> UpdatePerson( PersonDto personToUpdate );
        Task<Result> DeletePerson( int personId );
    }
}
