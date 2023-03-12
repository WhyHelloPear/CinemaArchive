using FluentResults;

namespace Domain.Contracts
{
    public interface IUnitOfWork
    {
        Result<int> SaveChanges(CancellationToken cancellationToken = default);
    }
}
