using AuthFlow.Api.Common.Http;
using AuthFlow.Domain.Common.Errors;
using AuthFlow.Domain.Common.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthFlow.Api.Controllers;

[ApiController]
[Authorize]
public class ApiController : ControllerBase
{
    protected IActionResult Problem(List<Error> errors)
    {
        if (errors.Count is 0)
            return Problem();

        if (errors.All(error => error.Type == ErrorType.Validation))
            return ValidationProblem(errors);

        HttpContext.Items[HttpContextItemKeys.Errors] = errors;

        var firstError = errors.Find(error => error.Type != ErrorType.Validation) ?? errors[0];

        return Problem(firstError);
    }

    private IActionResult Problem(Error error)
    {
        var statusCode = error.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(statusCode: statusCode, title: error.Message);
    }

    private IActionResult ValidationProblem(List<Error> errors)
    {
        var validationProblemDetails = new ValidationProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Title = "One or more validation errors occurred.",
            Detail = "See the errors property for details.",
            Instance = HttpContext.Request.Path
        };

        foreach (var error in errors)
        {
            validationProblemDetails.Errors.Add(error.Code, new[] { error.Message });
        }

        return ValidationProblem(validationProblemDetails);
    }
}