using BookMaster.Domain.Entities;

namespace BookMaster.Domain.Repositories.Books;
public interface IBooksReadOnlyRepository
{
    Task<Book?> GetById(long id);
}
