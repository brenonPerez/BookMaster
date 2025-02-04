using BookMaster.Domain.Entities;

namespace BookMaster.Domain.Repositories.Books;
public interface IBooksWriteOnlyRepository
{
    Task Add(Book book);
    Task<bool> Delete(long id);
}
