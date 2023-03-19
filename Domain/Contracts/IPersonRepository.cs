using Core.Domain.Models;
using FluentResults;

namespace Domain.Contracts
{
    public interface IPersonRepository
    {
        //Person Methods
        Task<int> GetNumPeople();
        Task<IEnumerable<Person>> GetPeople();
        Task<Result<int>> DeletePerson( int personId );
        Task<Result<int>> InsertPerson( Person person );
        Task<Result<int>> UpdatePerson( Person person );

        //Position Methods
        Task<IQueryable<FilmRole>> GetPositions();
        Task<Result<int>> DeletePosition( int positionId );
        Task<Result<int>> InsertPosition( FilmRole position );
        Task<Result<int>> UpdatePosition( FilmRole position );
    }
}
