using BookMaster.Domain.Entities;

namespace BookMaster.Domain.Repositories.Books;
public interface IBooksOnlyRepository
{
    Task Add(Book book);
}
