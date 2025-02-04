using AutoMapper;
using BookMaster.Communication.Responses;
using BookMaster.Domain.Repositories.Books;

namespace BookMaster.Application.UseCases.Books.GetByFilters;
public class GetBooksByFiltersUseCase : IGetBooksByFiltersUseCase
{
    private IBooksReadOnlyRepository _booksReadOnlyRepository;
    private IMapper _mapper;

    public GetBooksByFiltersUseCase(
        IBooksReadOnlyRepository booksReadOnlyRepository,
        IMapper mapper)
    {
        _booksReadOnlyRepository = booksReadOnlyRepository;
        _mapper = mapper;
    }

    public async Task<ResponseBooksJson> Execute(string? title, string? author, string? publisher)
    {
        var books = await _booksReadOnlyRepository.GetByFilters(title, author, publisher);
        return new ResponseBooksJson
        {
            Books = _mapper.Map<List<ResponseBookJson>>(books)
        };
    }
}
