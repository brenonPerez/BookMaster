using BookMaster.Domain.Entities;
using BookMaster.Domain.Repositories.Books;
using Microsoft.EntityFrameworkCore;

namespace BookMaster.Infrastructure.DataAccess.Repositories.Books;
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

    public async Task<List<Book>> GetByFilters(string? title, string? author, string? publisher)
    {
        return await _dbContext.Books
            .AsNoTracking()
            .Where(book =>
                (string.IsNullOrEmpty(title) || book.Title.Contains(title)) &&
                (string.IsNullOrEmpty(author) || book.Author.Contains(author)) &&
                (string.IsNullOrEmpty(publisher) || book.Publisher.Contains(publisher))
            )
            .ToListAsync();
    }
}
