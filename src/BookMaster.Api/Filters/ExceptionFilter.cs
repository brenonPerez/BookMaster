using BookMaster.Communication.Responses;
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
            var errorResponse = new ResponseErrorJson(validationException.Errors.Select(e => e.ErrorMessage).ToList());
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new ObjectResult(errorResponse);
        }
        else
        {
            var errorResponse = new ResponseErrorJson("Ocorreu um erro desconhecido no servidor.");
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(errorResponse);
        }
    }
}
