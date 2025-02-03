using BookMaster.Communication.Requests;
using BookMaster.Communication.Responses;
using BookMaster.Domain.Repositories.Books;
using BookMaster.Domain.Entities;

namespace BookMaster.Application.UseCases.Book.Register;
public class RegisterBookUseCase : IRegisterBookUseCase
{
    private readonly IBooksOnlyRepository _booksOnlyRepository;
    public RegisterBookUseCase(IBooksOnlyRepository booksOnlyRepository)
    {
        _booksOnlyRepository = booksOnlyRepository;
    }

    public async Task<ResponseBookJson> Execute(RequestBookJson request)
    {
        var bookEntity = new BookMaster.Domain.Entities.Book
        {
            Title = request.Title,
            Author = request.Author,
            Publisher = request.Publisher,
            Year = request.Year,
            Summary = request.Summary
        };

        await _booksOnlyRepository.Add(bookEntity);

        return new ResponseBookJson
        {
            Id = bookEntity.Id,
            Title = bookEntity.Title,
            Author = bookEntity.Author,
            Publisher = bookEntity.Publisher,
            Year = bookEntity.Year,
            Summary = bookEntity.Summary
        };
    }
}
