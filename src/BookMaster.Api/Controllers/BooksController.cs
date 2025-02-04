using BookMaster.Application.UseCases.Book.Register;
using BookMaster.Communication.Requests;
using BookMaster.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BookMaster.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseBookJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(
        [FromBody] RequestBookJson request,
        [FromServices] IRegisterBookUseCase useCase)
    {
        var response = await useCase.Execute(request);
        return Created(string.Empty, response);
    }
}
