using BookMaster.Communication.Requests;

namespace BookMaster.Application.UseCases.Books.Update;
public interface IUpdateBookUseCase
{
    Task Execute(long id, RequestBookJson request);
}
