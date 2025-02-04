using BookMaster.Domain.Repositories.Books;
using BookMaster.Infrastructure.DataAccess;
using BookMaster.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookMaster.Infrastructure;
public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext(configuration);
        services.AddRepositories();
    }

    private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {

        var connectionString = configuration.GetConnectionString("Connection");
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 40));

        services.AddDbContext<BookMasterDbContext>(config => config.UseMySql(connectionString, serverVersion));
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBooksWriteOnlyRepository, BooksWriteOnlyRepository>();
        services.AddScoped<IBooksReadOnlyRepository, BooksReadOnlyRepository>();
    }
}

