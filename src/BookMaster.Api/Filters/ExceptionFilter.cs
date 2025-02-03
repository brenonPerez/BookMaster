using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookMaster.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is ValidationException validationException)
        {
            context.Result = new BadRequestObjectResult(new
            {
                Errors = validationException.Errors.Select(e => e.ErrorMessage)
            });
            context.ExceptionHandled = true;
        }
        else
        {
            context.Result = new ObjectResult(new
            {
                Message = "Ocorreu um erro desconhecido no servidor."
            })
            {
                StatusCode = 500
            };
            context.ExceptionHandled = true;
        }
    }
}
