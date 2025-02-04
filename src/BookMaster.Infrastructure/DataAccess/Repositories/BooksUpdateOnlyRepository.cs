using BookMaster.Domain.Entities;
using BookMaster.Domain.Repositories.Books;
using Microsoft.EntityFrameworkCore;

namespace BookMaster.Infrastructure.DataAccess.Repositories;
internal class BooksUpdateOnlyRepository : IBooksUpdateOnlyRepository
{
    private readonly BookMasterDbContext _dbContext;
    public BooksUpdateOnlyRepository(BookMasterDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Book?> GetById(long id)
    {
        return await _dbContext.Books.FirstOrDefaultAsync(e => e.Id == id);
    }

    public void Update(Book book)
    {
        _dbContext.Books.Update(book);
    }
}
