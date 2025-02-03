using BookMaster.Domain.Entities;
using BookMaster.Domain.Repositories.Books;

namespace BookMaster.Infrastructure.DataAccess.Repositories;
internal class BooksOnlyRepository : IBooksOnlyRepository
{
    private readonly BookMasterDbContext _dbContext;
    public BooksOnlyRepository(BookMasterDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(Book book)
    {
        await _dbContext.Books.AddAsync(book);
        await _dbContext.SaveChangesAsync();
    }
}
