using AutoMapper;
using BookMaster.Communication.Responses;
using BookMaster.Domain.Repositories.Books;
using BookMaster.Exception.ExceptionBase;

namespace BookMaster.Application.UseCases.Books.GetById;
public class GetBookByIdUseCase : IGetBookByIdUseCase
{
    private IBooksReadOnlyRepository _booksReadOnlyRepository;
    private IMapper _mapper;

    public GetBookByIdUseCase(
        IBooksReadOnlyRepository booksReadOnlyRepository,
        IMapper mapper)
    {
        _booksReadOnlyRepository = booksReadOnlyRepository;
        _mapper = mapper;
    }

    public async Task<ResponseBookJson> Execute(long id)
    {
        var book = await _booksReadOnlyRepository.GetById(id);

        if (book is null)
        {
            throw new NotFoundException("O livro não foi encontrado");
        }

        return _mapper.Map<ResponseBookJson>(book);
    }
}
