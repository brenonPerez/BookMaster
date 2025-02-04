using BookMaster.Domain.Repositories;

namespace BookMaster.Infrastructure.DataAccess.Repositories;
internal class UnitOfWork : IUnitOfWork
{
    private readonly BookMasterDbContext _dbContext;
    public UnitOfWork(BookMasterDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Commit()
    {
        await _dbContext.SaveChangesAsync();
    }
}
