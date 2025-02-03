using BookMaster.Communication.Requests;
using BookMaster.Communication.Responses;

namespace BookMaster.Application.UseCases.Book.Register;
public interface IRegisterBookUseCase
{
    Task<ResponseBookJson> Execute(RequestBookJson request);
}
