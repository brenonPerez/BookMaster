using BookMaster.Domain.Entities;
using BookMaster.Domain.Repositories.Books;
using Microsoft.EntityFrameworkCore;

namespace BookMaster.Infrastructure.DataAccess.Repositories;
internal class BooksReadOnlyRepository : IBooksReadOnlyRepository
{
    private readonly BookMasterDbContext _dbContext;
    public BooksReadOnlyRepository(BookMasterDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Book?> GetById(long id)
    {
        return await _dbContext.Books.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
    }
}
