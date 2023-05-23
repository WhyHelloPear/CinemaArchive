using Core.Domain.Models;
using FluentResults;

namespace Core.Domain.Services
{
    public interface IPersonService
    {
        Task<List<Person>> GetPeople();
        Task<Result> CreatePerson( Person person );
        Task<Result> UpdatePerson( Person personToUpdate );
        Task<Result> DeletePerson( int personId );
    }
}
