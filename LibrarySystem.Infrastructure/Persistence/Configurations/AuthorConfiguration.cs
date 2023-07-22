using LibrarySystem.Domain.AuthorAggregate;
using LibrarySystem.Domain.AuthorAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibrarySystem.Infrastructure.Persistence.Configuration;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable("Authors");
        builder.HasKey(pk => pk.Id);
        builder
            .Property(pk => pk.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Id, value => AuthorId.Create(value));
        builder.Property(fn => fn.FirstName).HasColumnType("varchar").HasMaxLength(50).IsRequired();
        builder.Property(ln => ln.LastName).HasColumnType("varchar").HasMaxLength(50).IsRequired();
    }
}
