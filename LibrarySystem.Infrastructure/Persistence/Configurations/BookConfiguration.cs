using LibrarySystem.Domain.AuthorAggregate.ValueObjects;
using LibrarySystem.Domain.BookAggregate;
using LibrarySystem.Domain.BookAggregate.ValueObjects;
using LibrarySystem.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibrarySystem.Infrastructure.Persistence.Configuration;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books");
        builder.HasKey(pk => pk.Id);
        builder
            .Property(pk => pk.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Id, value => BookId.Create(value));
        builder.Property(ti => ti.Title).HasColumnType("varchar").HasMaxLength(255).IsRequired();
        builder.Property(d => d.Description).HasColumnType("varchar").HasMaxLength(255);
        builder.Property(py => py.PublishedYear);
        builder.Property(b => b.IsBorrowed);

        builder
            .Property(aid => aid.AuthorId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Id, value => AuthorId.Create(value));

        builder
            .Property(uid => uid.UserId)
            .ValueGeneratedNever()
            .HasConversion(id => id.Id, value => UserId.Create(value));

        // builder.HasOne(au => au.Author).WithMany(bo => bo.Books).HasForeignKey(fk => fk.AuthorId);
        // builder.HasOne(u => u.User).WithMany(bo => bo.BorrowedBooks).HasForeignKey(fk => fk.UserId);
    }
}
