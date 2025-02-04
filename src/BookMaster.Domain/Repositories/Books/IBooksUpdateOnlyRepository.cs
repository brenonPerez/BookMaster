using BookMaster.Domain.Entities;

namespace BookMaster.Domain.Repositories.Books;
public interface IBooksUpdateOnlyRepository
{
    Task<Book?> GetById(long  id);
    void Update(Book book);
}
