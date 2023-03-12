using Domain.Models;
using FluentResults;

namespace Domain.Contracts
{
    public interface IPersonRepository
    {
        //Person Methods
        IQueryable<Person> GetPeople();
        Result<int> DeletePerson(int personId);
        Result<int> InsertPerson(Person person);
        Result<int> UpdatePerson(Person person);

        //Position Methods
        IQueryable<Position> GetPositions();
        Result<int> DeletePosition(int positionId);
        Result<int> InsertPosition(Position position);
        Result<int> UpdatePosition(Position position);
    }
}
