namespace Management.Domain.Abstractions.Interfaces;

public interface IUnitOfWork
{
    Task CommitAsync();
}