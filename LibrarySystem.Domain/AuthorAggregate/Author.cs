using LibrarySystem.Domain.AuthorAggregate.ValueObjects;
using LibrarySystem.Domain.BookAggregate;
using LibrarySystem.Domain.Models;

namespace LibrarySystem.Domain.AuthorAggregate;

public class Author : AggregateRoot<AuthorId>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    private Author() { }

    private Author(AuthorId authorId, string firstName, string lastName)
        : base(authorId)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public static Author CreateAuthor(string firstName, string lastName)
    {
        return new Author(AuthorId.CreateUnique(), firstName, lastName);
    }
}
