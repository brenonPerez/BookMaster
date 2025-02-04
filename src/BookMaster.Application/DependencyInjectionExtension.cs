using BookMaster.Application.AutoMapper;
using BookMaster.Application.UseCases.Books.GetById;
using BookMaster.Application.UseCases.Books.Register;
using Microsoft.Extensions.DependencyInjection;

namespace BookMaster.Application;
public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddUseCases();
        services.AddAutoMapper();
    }

    private static void AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<IRegisterBookUseCase, RegisterBookUseCase>();
        services.AddScoped<IGetBookByIdUseCase, GetBookByIdUseCase>();
    }

    public static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }
}
