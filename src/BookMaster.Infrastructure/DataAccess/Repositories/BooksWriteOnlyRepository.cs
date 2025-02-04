using BookMaster.Domain.Entities;
using BookMaster.Domain.Repositories.Books;

namespace BookMaster.Infrastructure.DataAccess.Repositories;
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
        await _dbContext.SaveChangesAsync();
    }
}
