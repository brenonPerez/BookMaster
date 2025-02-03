using BookMaster.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookMaster.Infrastructure.Migrations;
public class DataBaseMigration
{
    public static async Task MigrateDatabase(IServiceProvider serviceProvider)
    {
        var dbContext = serviceProvider.GetRequiredService<BookMasterDbContext>();

        await dbContext.Database.MigrateAsync();
    }
}
