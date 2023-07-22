using LibrarySystem.Application.Common.Interfaces;
using LibrarySystem.Domain.AuthorAggregate;

namespace LibrarySystem.Infrastructure.Persistence.Repositories;

public class AuthorRepository : GenericsRepository<Author>, IAuthorRepository
{
    public AuthorRepository(AppDbContext context)
        : base(context) { }
}
