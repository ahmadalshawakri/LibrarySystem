using LibrarySystem.Domain.AuthorAggregate;
using LibrarySystem.Domain.AuthorAggregate.ValueObjects;
using LibrarySystem.Domain.BookAggregate.ValueObjects;
using LibrarySystem.Domain.Models;
using LibrarySystem.Domain.UserAggregate;
using LibrarySystem.Domain.UserAggregate.ValueObjects;

namespace LibrarySystem.Domain.BookAggregate;

public class Book : AggregateRoot<BookId>
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public int PublishedYear { get; private set; }
    public bool IsBorrowed { get; private set; }
    public AuthorId AuthorId { get; private set; }
    public UserId UserId { get; private set; }

    private Book() { }

    private Book(
        BookId bookId,
        string title,
        AuthorId authorId,
        string description,
        int publishedYear
    )
        : base(bookId)
    {
        this.Title = title;
        this.AuthorId = authorId;
        this.Description = description;
        this.PublishedYear = publishedYear;
        this.IsBorrowed = false;
    }

    public Book CreateBook(string title, AuthorId authorId, string description, int publishedYear)
    {
        return new Book(BookId.CreateUnique(), title, authorId, description, publishedYear);
    }

    public void BorrowBook(User user)
    {
        if (IsBorrowed)
        {
            // TODO: Throw exception
        }

        this.IsBorrowed = true;
        this.UserId = user.Id;

        // TODO: Add to Domain Event
    }

    public void ReturnBook()
    {
        if (!IsBorrowed)
        {
            // TODO: Throw exception
        }

        this.IsBorrowed = false;
        this.UserId = null;

        // TODO: Add to Domain Event
    }
}
