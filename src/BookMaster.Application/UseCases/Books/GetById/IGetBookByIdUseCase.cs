using BookMaster.Communication.Responses;

namespace BookMaster.Application.UseCases.Books.GetById;
public interface IGetBookByIdUseCase
{
    Task<ResponseBookJson> Execute(long id);
}
