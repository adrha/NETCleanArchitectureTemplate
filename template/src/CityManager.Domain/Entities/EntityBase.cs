namespace CityManager.Domain.Entities;

public abstract record EntityBase
{
    public Guid Id { get; init; }
}