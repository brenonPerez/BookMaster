using BookMaster.Communication.Responses;

namespace BookMaster.Application.UseCases.Books.GetByFilters;
public interface IGetBooksByFiltersUseCase
{
    Task<ResponseBooksJson> Execute(string? title, string? author, string? publisher);
}
