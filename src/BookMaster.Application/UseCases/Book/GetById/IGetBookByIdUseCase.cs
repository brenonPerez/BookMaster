using BookMaster.Communication.Responses;

namespace BookMaster.Application.UseCases.Book.GetById;
public interface IGetBookByIdUseCase
{
    Task<ResponseBookJson> Execute(long id);
}
