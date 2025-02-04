using BookMaster.Application.UseCases.Book.GetById;
using BookMaster.Application.UseCases.Book.Register;
using Microsoft.Extensions.DependencyInjection;

namespace BookMaster.Application;
public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddUseCases();
    }

    private static void AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<IRegisterBookUseCase, RegisterBookUseCase>();
        services.AddScoped<IGetBookByIdUseCase, GetBookByIdUseCase>();
    }
}
