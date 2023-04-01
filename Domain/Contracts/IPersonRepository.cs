using Core.Domain.Models;
using FluentResults;

namespace Domain.Contracts
{
    public interface IPersonRepository
    {
        //Person Methods
        Task<int> GetNumPeople();
        Task<List<Person>> GetPeople();
        Task<int> CreatePerson(Person person);
        Task<int> UpdatePerson( Person person );
        Task<int> DeletePerson( int personId );
    }
}
