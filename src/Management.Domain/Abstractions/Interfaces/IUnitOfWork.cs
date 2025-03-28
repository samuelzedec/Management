namespace Managment.Domain.Abstractions.Interfaces;

public interface IUnitOfWork
{
    Task CommitAsync();
}