using LibrarySystem.Domain.Models;

namespace LibrarySystem.Domain.AuthorAggregate.ValueObjects;

public class AuthorId : ValueObject
{
    public Guid Id { get; }

    private AuthorId(Guid id)
    {
        Id = id;
    }

    public static AuthorId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static AuthorId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
}
