using LibrarySystem.Domain.UserAggregate;
using LibrarySystem.Domain.UserAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibrarySystem.Infrastructure.Persistence.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(pk => pk.Id);
        builder
            .Property(pk => pk.Id)
            .ValueGeneratedNever()
            .HasConversion(id => id.Id, value => UserId.Create(value));
        builder.Property(e => e.Email).HasColumnType("varchar").HasMaxLength(50).IsRequired();
        builder.Property(p => p.Password).HasColumnType("varchar").HasMaxLength(50).IsRequired();
        builder.OwnsOne(
            e => e.Address,
            address =>
            {
                address.Property(a => a.Street).HasMaxLength(100);
                address.Property(a => a.City).HasMaxLength(50);
                address.Property(a => a.PostalCode).HasMaxLength(20);
                address.Property(a => a.Country).HasMaxLength(50);
            }
        );

        // builder.OwnsMany(
        //     m => m.BookIds,
        //     bo =>
        //     {
        //         bo.ToTable("BookIds");
        //         bo.WithOwner().HasForeignKey("UserId");
        //         bo.HasKey("Id");
        //         bo.Property(d => d.Id).HasColumnName("BookId").ValueGeneratedNever();
        //     }
        // );
    }
}
