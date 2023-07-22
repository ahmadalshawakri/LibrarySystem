using LibrarySystem.Domain.BookAggregate;
using LibrarySystem.Domain.BookAggregate.ValueObjects;
using LibrarySystem.Domain.Models;
using LibrarySystem.Domain.UserAggregate.ValueObjects;

namespace LibrarySystem.Domain.UserAggregate;

public class User : AggregateRoot<UserId>
{
    public string Email { get; private set; }
    public string Password { get; private set; }
    public Address Address { get; private set; }

    private User(UserId userId, string email, string password, Address address)
        : base(userId)
    {
        this.Email = email;
        this.Password = password;
        this.Address = address;
    }

    private User() { }

    public static User CreateUser(string email, string password, Address address)
    {
        return new User(UserId.CreateUnique(), email, password, address);
    }

    // public void AddBook(Book book)
    // {
    //     if (!book.IsBorrowed)
    //         BorrowedBooks.Add(book);
    // }
}
