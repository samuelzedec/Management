namespace Management.Domain.Abstractions.Base;

public abstract class Entity
{
    public Guid Id { get; private set; } = Guid.NewGuid();
}