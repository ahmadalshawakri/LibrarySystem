using LibrarySystem.Application.Common.Interfaces;
using LibrarySystem.Domain.BookAggregate;

namespace LibrarySystem.Infrastructure.Persistence.Repositories;

public class BookRepository : GenericsRepository<Book>, IBookRepository
{
    public BookRepository(AppDbContext context)
        : base(context) { }
}
