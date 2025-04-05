using Management.Domain.Abstractions.Base;

namespace Management.Domain.Entities;

public class ExpenseType(string title, string description) : Entity
{
    public string Title { get; private set; } = title;
    public string Description { get; private set; } = description;
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
}