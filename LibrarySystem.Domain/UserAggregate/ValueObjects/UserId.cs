using LibrarySystem.Domain.Models;

namespace LibrarySystem.Domain.UserAggregate.ValueObjects;

public class UserId : ValueObject
{
    public Guid Id { get; }

    private UserId(Guid id)
    {
        Id = id;
    }

    public static UserId CreateUnique()
    {
        // TODO: Enfornce Invariants
        return new(Guid.NewGuid());
    }

    public static UserId Create(Guid value)
    {
        // TODO: Enfornce Invariants
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
}
