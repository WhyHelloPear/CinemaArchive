using Domain.Models;
using FluentResults;

namespace Domain.Contracts
{
    public interface IPersonRepository
    {
        //Person Methods
        Task<IQueryable<Person>> GetPeople();
        Task<Result<int>> DeletePerson(int personId);
        Task<Result<int>> InsertPerson(Person person);
        Task<Result<int>> UpdatePerson(Person person);

        //Position Methods
        Task<IQueryable<Position>> GetPositions();
        Task<Result<int>> DeletePosition(int positionId);
        Task<Result<int>> InsertPosition(Position position);
        Task<Result<int>> UpdatePosition(Position position);
    }
}
