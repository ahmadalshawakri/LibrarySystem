using LibrarySystem.Domain.AuthorAggregate;
using LibrarySystem.Domain.BookAggregate;
using LibrarySystem.Domain.UserAggregate;
using LibrarySystem.Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Book> Books { get; set; } = null!;

    // public DbSet<Author> Authors { get; set; } = null!;

    public AppDbContext(DbContextOptions options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new UserConfiguration().Configure(modelBuilder.Entity<User>());
        new BookConfiguration().Configure(modelBuilder.Entity<Book>());
        new AuthorConfiguration().Configure(modelBuilder.Entity<Author>());
        base.OnModelCreating(modelBuilder);
    }
}
