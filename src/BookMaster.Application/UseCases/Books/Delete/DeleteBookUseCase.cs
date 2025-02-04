using BookMaster.Domain.Repositories;
using BookMaster.Domain.Repositories.Books;
using BookMaster.Domain.Resources.Books;
using BookMaster.Exception.ExceptionBase;

namespace BookMaster.Application.UseCases.Books.Delete;
public class DeleteBookUseCase : IDeleteBookUseCase
{
    private readonly IBooksWriteOnlyRepository _booksOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteBookUseCase(
        IBooksWriteOnlyRepository booksOnlyRepository, 
        IUnitOfWork unitOfWork)
    {
        _booksOnlyRepository = booksOnlyRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(long id)
    {
        var result = await _booksOnlyRepository.Delete(id);

        if(result is false)
        {
            throw new NotFoundException(ResourceBookMessages.NOT_FOUND_BOOK);
        }

        await _unitOfWork.Commit();
    }
}
