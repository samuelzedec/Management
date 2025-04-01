using Management.Domain.Abstractions.Interfaces;

namespace Management.Infrastructure.Data;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CommitAsync()
        => await context.SaveChangesAsync();
}