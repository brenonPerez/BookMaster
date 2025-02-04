using AutoMapper;
using BookMaster.Communication.Requests;
using BookMaster.Domain.Repositories;
using BookMaster.Domain.Repositories.Books;
using BookMaster.Exception.ExceptionBase;

namespace BookMaster.Application.UseCases.Books.Update;
public class UpdateBookUseCase : IUpdateBookUseCase
{
    private readonly IMapper _mapper;
    private readonly IBooksUpdateOnlyRepository _booksUpdateOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateBookUseCase(
        IMapper mapper, 
        IBooksUpdateOnlyRepository booksUpdateOnlyRepository,
        IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _booksUpdateOnlyRepository = booksUpdateOnlyRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(long id, RequestBookJson request)
    {
        Validate(request);

        var book = await _booksUpdateOnlyRepository.GetById(id);

        if (book is null)
        {
            throw new NotFoundException("O livro não foi encontrado");
        }

        _mapper.Map(request, book);

        _booksUpdateOnlyRepository.Update(book);

        await _unitOfWork.Commit();
    }

    private void Validate(RequestBookJson request)
    {
        var validation = new BookValidator();

        var result = validation.Validate(request);

        if (result.IsValid is false)
        {
            var errorMessages = result.Errors.Select(r => r.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
