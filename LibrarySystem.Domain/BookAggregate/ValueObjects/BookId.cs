using LibrarySystem.Domain.Models;

namespace LibrarySystem.Domain.BookAggregate.ValueObjects;

public class BookId : ValueObject
{
    public Guid Id { get; }

    private BookId(Guid id)
    {
        Id = id;
    }

    public static BookId CreateUnique()
    {
        // TODO: Enfornce Invariants
        return new(Guid.NewGuid());
    }

    public static BookId Create(Guid value)
    {
        // TODO: Enfornce Invariants
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
}
