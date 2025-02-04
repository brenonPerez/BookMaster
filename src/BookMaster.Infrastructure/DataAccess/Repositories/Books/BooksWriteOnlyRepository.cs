using BookMaster.Domain.Entities;
using BookMaster.Domain.Repositories.Books;
using Microsoft.EntityFrameworkCore;

namespace BookMaster.Infrastructure.DataAccess.Repositories.Books;
internal class BooksWriteOnlyRepository : IBooksWriteOnlyRepository
{
    private readonly BookMasterDbContext _dbContext;
    public BooksWriteOnlyRepository(BookMasterDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Book book)
    {
        await _dbContext.Books.AddAsync(book);
    }

    public async Task<bool> Delete(long id)
    {
        var expense = await _dbContext.Books.FirstOrDefaultAsync(e => e.Id == id);
        if (expense is null)
        {
            return false;
        }

        _dbContext.Books.Remove(expense);
        return true;
    }
}
