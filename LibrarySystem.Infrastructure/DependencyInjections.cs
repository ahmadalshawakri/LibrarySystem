using LibrarySystem.Application.Common.Interfaces;
using LibrarySystem.Infrastructure.Persistence;
using LibrarySystem.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibrarySystem.Infrastructure;

public static class DependencyInjections
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration
    )
    {
        services.AddDbContext<AppDbContext>(
            options =>
                options.UseNpgsql(
                    "Server=localhost;Port=5432;Database=LibrarySystem;Username=AhmadShawakri;Password=1234"
                )
        );
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericsRepository<>));
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();

        return services;
    }
}
